    using System;
    using System.Windows.Forms;
    
    namespace PositioningCs
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                /*
                IntPtr h = this.Handle;
                this.Top = 0;
                this.Left = 0;
                */
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Top = 0;
                this.Left = 0;
            }
        }
    }
