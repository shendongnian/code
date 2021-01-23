    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)   
            {
                label1.Text = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(label1.Text);
            }
     }
