    you are using int and when you are dividing it by 
    
    (1000/300) it will result 0.3. But the data type is int, so result is 0;
    
    Please use below code
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace thered_Try
    {
        public partial class Form1 : Form
        {
            decimal res =0;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                decimal oneee = 300;
                decimal two = 1000;
                decimal thee = 10;
                res = (oneee / two) * 10;
                label1.Text = res.ToString();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
        }
    }
    
    Thanks, Let me know your result. 
