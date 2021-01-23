     public partial class Form1 : Form
        {
            public Form1 _Form1;
            string input;
            public delegate void SetTextCallback(string text);
    
            public Form1()
            {
                InitializeComponent();
                _Form1 = this;
            }
    
            public void ThreadSafe(string text)
            {
                if (this.screenTextBox.InvokeRequired)
                {
                    // It's on a different thread, so use Invoke.
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text + " (Invoke)" });
                }
                else
                {
                    // It's on the same thread, no need for Invoke
                    this.screenTextBox.Text = text + " (No Invoke)";
    
                }
            }
    
    
    
            // This method is passed in to the SetTextCallBack delegate
            // to set the Text property of textBox1.
            private void SetText(string text)
            {
                this.screenTextBox.Text = text;
            } 
        }
