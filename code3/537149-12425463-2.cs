    public partial class Form1 : Form
    {
        private Random r = new Random();
        private int[] counts = new int[20];
        private static string newLine = Environment.NewLine;
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
                    // Upper bound is EXCLUSIVE
                    var gen = r.Next(1, 21);
                    counts[gen - 1]++;
                }
                this.textBox2.Text += PrintResults(this.counts);
            }
            else
            {
                this.textBox2.Text += "Invalid input! Cannot generate numbers." + newLine;
            }
        }
        private static string PrintResults(int[] counts)
        {
            if (counts == null)
            {
                return string.Empty;
            }
            string result = string.Empty;
            for (int i = 0; i < counts.Length; i++)
            {
                result += "Number " + (i + 1) + " generated " + counts[i] + " times." + newLine;
            }
            return result;
        }
    }
