      public partial class Form1: Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          Form2 form2 = new Form2();
          this.Hide();
          form2.ShowDialog();
          this.Show();
        }
      }
      public partial class Form2: Form
      {
        public Form2()
        {
          InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          Close();
        }
      }
