    public partial class Form1 : 
    {
        private Random r = new Random();
        private int[] counts = new int[20];
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(this.textBox1.Text, out n))
            {
                for (int i = 0; i < n; i++)
                {
                    var gen = r.Next(1, 20);
                    counts[gen]++;
                }
            }
        }
    }
