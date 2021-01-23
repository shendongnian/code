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
                // Clear the box
                this.textBox2.Text = string.Empty;
                var generatedList = new int[n];
                for (int i = 0; i < n; i++)
                {
                    // Upper bound is EXCLUSIVE
                    var gen = r.Next(1, 21);
                    counts[gen - 1]++;
                    generatedList[i] = gen;
                }
                this.textBox2.Text += PrintNumbers(generatedList);
                this.textBox2.Text += PrintCounts(this.counts);
            }
            else
            {
                this.textBox2.Text = "Invalid input! Cannot generate numbers.";
            }
        }
        private static string PrintNumbers(int[] numbers)
        {
            if (numbers == null)
            {
                return "No numbers generated" + newLine;
            }
            string result = "Generated sequence: {";
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
                if (i < numbers.Length - 1)
                {
                    result += ", ";
                }
            }
            return result + "}" + newLine;
        }
        private static string PrintCounts(int[] counts)
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
