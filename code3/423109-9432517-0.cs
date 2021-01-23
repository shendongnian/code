    public partial class Form2 : Form
    {
        public Form2()
        {
            CalculateValues myAdd = new CalculateValues();
            MulitplyValues Add = new MulitplyValues();
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
    
            int total = myAdd.Calculate(int.Parse(textBox1.Text), int.Parse(textBox2.Text));    
            MessageBox.Show(total.ToString());
    
        }
