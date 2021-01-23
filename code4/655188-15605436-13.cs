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
                // We make a copy of ButtonClicked before checking it for null because
                // in a multithreaded environment some other thread could change it to null
                // just after we checked it for nullness but before we call it, which would
                // cause a null reference exception.
                // A copy cannot be changed by another thread, so that's safe to use:
                var handler = ButtonClicked;
                if (handler != null)
                    handler(sender, e);
            }
        }
    }
