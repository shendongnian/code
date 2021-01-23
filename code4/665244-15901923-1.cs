        public partial class Form1 : Form
        { 
            bool buttonvisible = false;
    
            public Form1()
            {
                InitializeComponent();
                button1.Visible = false;
                button1.Click += button1_Click;
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                if(buttonvisible)
                {
                    buttonvisible = false;
                    button1.Visible = false;
                }
                else
                {
                    buttonvisible = true;
                    button1.Visible = true;
                }
            }
        }
