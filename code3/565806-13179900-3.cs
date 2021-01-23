    public partial class Form1 : Form
    {
            StringBuilder exBuilder;
            public Form2()
            {
                InitializeComponent();
                exBuilder = new StringBuilder();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                exBuilder.Clear();
                MyMethod();
                //and all your other methods that have exBuilder.Append in their try-catch blocks
                richTextBox1.Text = exBuilder.ToString();
            }
    
            void MyMethod()
            {
                try
                {
                    //you code or whatever
                }
                catch(Exception e)
                {
                    exBuilder.Append("Error message below: \n\"" + String.Format("Configs #{0} NOT consistent : {1}", parameter, e.Message) + "\"" + Environment.NewLine);
                }
            }
    }
