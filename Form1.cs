using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_42
{
    public partial class Form_main : Form
    {
        Model modelA;
        Model modelB;
        Model modelC;

        public Form_main()
        {
            InitializeComponent();
            modelA = new Model();
            modelB = new Model();
            modelC = new Model();
            modelA.observer += new System.EventHandler(this.UpdateModel);
            modelB.observer += new System.EventHandler(this.UpdateModel);
            modelC.observer += new System.EventHandler(this.UpdateModel);
            modelC.setValue(100);
        }
      
        private void num_A_ValueChanged(object sender, EventArgs e)
        {
            modelA.setValue(Decimal.ToInt32(num_A.Value));
        }

        private void tb_A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modelA.setValue(Int32.Parse(tb_A.Text));
            }
        }
        private void track_A_Scroll(object sender, EventArgs e)
        {
            modelA.setValue(track_A.Value);
        }

        private void num_B_ValueChanged(object sender, EventArgs e)
        {
            modelB.setValue(Decimal.ToInt32(num_B.Value));
        }

        private void tb_B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modelB.setValue(Int32.Parse(tb_B.Text));
            }

        }

        private void track_B_Scroll(object sender, EventArgs e)
        {
            modelB.setValue(track_B.Value);
        }

        private void num_C_ValueChanged(object sender, EventArgs e)
        {
            modelC.setValue(Decimal.ToInt32(num_C.Value));
        }

        private void tb_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modelC.setValue(Int32.Parse(tb_C.Text));
            }

        }

        private void track_C_Scroll(object sender, EventArgs e)
        {
            modelC.setValue(track_C.Value);
        }

        private void UpdateModel(object sender, EventArgs e)
        {
            tb_A.Text = modelA.getValue().ToString();
            num_A.Value = modelA.getValue();
            track_A.Value = modelA.getValue();
            modelB.setMin(modelA.getValue());


            tb_B.Text = modelB.getValue().ToString();
            num_B.Value = modelB.getValue();
            track_B.Value = modelB.getValue();
            modelC.setMin(modelB.getValue());
            modelA.setMax(modelB.getValue());


            tb_C.Text = modelC.getValue().ToString();
            num_C.Value = modelC.getValue();
            track_C.Value = modelC.getValue();
            modelB.setMax(modelC.getValue());
        }
    }
}

public class Model
{
    private int value, max, min;
        
    public System.EventHandler observer;  
    public Model()
    {
        value = 0;
        max = 100;
        min = 0;
    }
    public void setValue(int _value)
    {
        if(_value <= max && _value >= min)
        {
            value = _value;   
        }        
        observer.Invoke(this, null);
    }    
    public int  getValue()
    {
        return value;
    }
    public void setMax(int _max)
    {
        max = _max;
    }
    public void setMin(int _min)
    {
        min = _min;
    }
}
