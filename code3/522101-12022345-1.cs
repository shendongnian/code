    public partial class Form3 : Form
    {
        public String sti { get; set; }
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sti = textBox1.Text;
            this.Close();
        }
    }
