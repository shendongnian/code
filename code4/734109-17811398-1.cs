       public partial class Form1 : Form
    {
        int n1, n2 = 0;
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
        public int tQuestion()
        {
            n1 = GetRandomNumber(2, 11);
            n2 = GetRandomNumber(2, 11);
            string tQues = n1 + " x " + n2 + " = ";
            label1.Text = tQues;
            return 0;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tQuestion();
        
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //make it empty. You need to attach tb_KeyDown event in properties
        }
        public void button1_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }
        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAnswer();
            }
        }
        private void CheckAnswer()
        {
            string tAns = textBox1.Text;
            int answer = n1 * n2;
            string tOrgAns = answer.ToString();
            if (tAns == tOrgAns)
                MessageBox.Show("Your answer is Corect", "Result", MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
            else
                MessageBox.Show("Your answer is WRONG", "Result", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            textBox1.Text = "";
            textBox1.Focus();
            tQuestion();
     }   
            
    }
