    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(textBox1.Text);
            
            // Hide Form1 before opening Form2.
            this.Hide();
            
            var dialogResult = frm2.ShowDialog(); // This method will freeze until you close Form2.
         
            // Then we show this form again. You can check the dialogResult if you want some logic.
            this.Show();
        }
    }
    
    public partial class Form2 : Form
    {
        public string txtbox;
    
        public Form2(string txtbox)
        {
            InitializeComponent();
            this.txtbox = txtbox;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = txtbox;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Not necessary, but good if you want to have some logic.
            
            // Close this form (Form2) and returns to the Form1 button1_Click.
            this.Close();
        }
    }
