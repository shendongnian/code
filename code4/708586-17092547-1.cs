    namespace TestApp
    {
        public partial class Form1 : Form
        {
            CalledClass call = new CalledClass();
   
            public Form1()
            {
                InitializeComponent();
                call.FormH = this;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                call.Call_UpdateBox();
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
            public static Form1 FormH;
            public void Call_UpdateBox()
            {
                //do looping for doing some tasks here and update textbox every time
                FormH.UpdateBox();
            }
        }
    }
