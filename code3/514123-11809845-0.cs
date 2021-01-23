      using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public  delegate string mystep ();
            public Queue<mystep> queuestep;
            public Form1()
            {
                InitializeComponent();
                queuestep = new Queue<mystep>();
                queuestep.Enqueue(step1);
                queuestep.Enqueue(step2);
                queuestep.Enqueue(step3);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (queuestep.Count >0)
                {
               mystep currentstep =  queuestep.Dequeue();
               textBox1.Text =currentstep();
               }
            }
    
            private string step1()
            {
                return "step1";
            }
            private string step2()
            {
                return "step2";
            }
            private string step3()
            {
                return "step3";
            }
        }
    }
