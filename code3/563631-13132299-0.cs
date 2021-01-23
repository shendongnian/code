    public partial class Form1 : Form
    {
        int roll1;
        int runningTotal;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            roll1 = rand.Next(6) + 1;
            int value = 100;
            int sum = (roll1 * value);
            runningTotal += sum;
            label1.Text = runningTotal.ToString("c");
        }
    }
