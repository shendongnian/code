    namespace Test
    {
        public partial class Form2 : Form
        {
            // Hold an instance to Form1
            private Form1 mForm1;
            public Form2(Form1 form1)
            {
                // Store instance to form1
                mForm1 = form1;
                InitializeComponent();
            }
    
            private void NewName_Click(object sender, EventArgs e)
            {
                // Change name on existing instance of form 1
                mForm1._Server("TEST");
                this.Close();
            }
        }
    }
