    using System;
    using System.Windows.Forms;
    
    namespace MouseForm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                this.Left = Cursor.Position.X - this.Width / 2;
                this.Top = Cursor.Position.Y - this.Height / 2;
            }
        }
    }
