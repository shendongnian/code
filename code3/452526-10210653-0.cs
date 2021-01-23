     public partial class Form1 : Form
        {
            public delegate void UpdateText(string text);
            public Form1()
            {
                InitializeComponent();
            }
            public void SetTextBoxText(string text)
            {
                // Check to see if invoke required - (from another thread)
                if(textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new UpdateText(this.SetTextBoxText),
                        
                        new object[]{text});
                }
                else
                {
                    textBox1.Text = text;
                }
            }
        }
