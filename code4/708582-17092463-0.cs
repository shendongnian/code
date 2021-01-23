    namespace TestApp
    {
        public partial class Form1 : Form
        {
            CalledClass call = new CalledClass();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                call.Call_UpdateBox(this);
            }
    
            public void UpdateBox()
            {
                textBox1.Text = "hello";
            }
        }
    }
    namespace TestApp
    {
        class CalledClass
        {
         public void Call_UpdateBox(Form1 Sender)
            {
                //do looping for doing some tasks here and update textbox every time
                sender.UpdateBox();
            }
        }
    }
