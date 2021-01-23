    public partial class Form1 : Form
    {
        private double cost;
        private double total;
        int amount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Order_Click(object sender, EventArgs e)
        {
            amount = int.Parse(textBox1.Text);
            cost *= amount;
            total += cost;
            ...
        }
