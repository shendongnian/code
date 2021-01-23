    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace teste1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_MouseEnter(object sender, EventArgs e)
            {
                button1.Image = ((System.Drawing.Image)(Properties.Resources.Botao_Del_Claro));
            }
                     
            private void button1_MouseDown(object sender, MouseEventArgs e)
            {
                button1.Image = ((System.Drawing.Image)(Properties.Resources.Botao_Del_Clique));              
            }
                
            private void button1_MouseLeave(object sender, EventArgs e)
            {
                button1.Image = ((System.Drawing.Image)(Properties.Resources.Botao_Del_Normal));
            }
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Image = ((System.Drawing.Image)(Properties.Resources.Botao_Del_Normal));
                // Processing is made here!
            }
                       
        }
    }
