    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            string mychar = "000000";
            string mtxt;
            int mypos = 6;
            public Form1()
            {
                InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = mychar;
        }
        
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                mtxt = mtxt + e.KeyChar;
                mypos--;
                mychar = mychar.Remove(mypos, mtxt.Length);
                mychar = mychar.Insert(mypos, mtxt);
                maskedTextBox1.Text = mychar;
            }
        }
    }
