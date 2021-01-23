    ublic partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string CheckButtonClick { get; set; }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckButtonClick == "login")
            {
                Form3 f3 = new Form3(); // Instantiate a Form3 object.  
                f3.Show(); // Show Form3 and  
                this.Close(); // closes the Form2 instance.  
            }
            else if (CheckButtonClick == "register")
            {
                Form4 f4 = new Form4(); // Instantiate a Form4 object.  
                f4.Show(); // Show Form4 and  
                this.Close(); // closes the Form2 instance.  
            } 
        }
    }
