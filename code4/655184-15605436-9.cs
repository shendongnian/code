    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1: Form
        {
            // Here's where we announce our event handler to the world:
            public event EventHandler ButtonClicked;
            public Form1()
            {
                InitializeComponent();
            }
            public void SetLabel(string text)
            {
                label1.Text = text;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                var handler = ButtonClicked;
                if (handler != null)
                    handler(sender, e);
            }
        }
    }
