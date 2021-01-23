    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string> { "a", "b", "c" };
            comboBox1.DataSource = list;
            comboBox1.SelectedIndex = 0;
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
                
        }
    }
