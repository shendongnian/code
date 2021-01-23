    using System;
    using System.Windows.Forms;
    
    namespace panelvisible
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void panel1_MouseHover(object sender, EventArgs e)
            {
                this.label1.Visible = true;
                this.label1.Enabled = true;
                this.panel2.Visible = true;
                this.panel2.Enabled = true;
            }
    
           
        }
    }
