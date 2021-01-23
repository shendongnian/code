    public partial class Form2 : Form
    {
        public string sti { get; set; } 
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sti = textBox1.Text;
            this.Hide();
        }
    }
