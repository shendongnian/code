    namespace Test   
    {   
        public partial class Form2 : Form   
        {   
            public Form2()   
            {   
                InitializeComponent();   
            }   
            public String ServerName { get; private set; } //Can only be set in this class, but read by all.
       
            private void NewName_Click(object sender, EventArgs e)   
            {   
                ServerName = "Test";   
                Close();   
            }   
        }   
    }  
