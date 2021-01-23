    ...
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            //give the variable a default value
            private bool data7=false;
            public Form2()
            {
                InitializeComponent();
            }
            public bool checkBox1 
            {
                get { return data7; }
                //Here is Furs Correction
                set { data7 = value; } 
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                if (data7 == true)
                {
                    label1.Text = "true";
                }
                else
                {
                    label1.Text = "false";
                }
            }
        }
    }
