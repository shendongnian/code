    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShowForm2("login");
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ShowForm2("register");
        } 
        private void ShowForm2(string formtype)
        {
            Form2 f2 = new Form2(); // Instantiate a Form2 object.
            f2.CheckButtonClick = formtype;
            f2.Show(this); // Show Form2 and  
            this.Hide(); // closes the Form1 instance.  
        }
    }
