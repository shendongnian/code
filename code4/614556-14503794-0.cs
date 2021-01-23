    public partial class Form1 : Form
    {
        Dictionary<Decimal, String> TextInfo;
        public Form1()
        {
            InitializeComponent();
            TextInfo= new Dictionary<Decimal, String>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            numPage.Value = 1;
        }
        private void bnForward_Click(object sender, EventArgs e)
        {
            if (TextInfo.ContainsKey(numPage.Value))
            {
                TextInfo[numPage.Value] = textBox1.Text;
            }
            else
            {
                TextInfo.Add(numPage.Value, textBox1.Text);
            }
            numPage.Value++;
            if (TextInfo.ContainsKey(numPage.Value))
            {
                textBox1.Text = TextInfo[numPage.Value];
            }
            else
            {
                textBox1.Text = "";
            }
        }
        private void bnBack_Click(object sender, EventArgs e)
        {
            if (numPage.Value == 1)
                return;
            if (TextInfo.ContainsKey(numPage.Value))
            {
                TextInfo[numPage.Value] = textBox1.Text;
            }
            else
            {
                TextInfo.Add(numPage.Value, textBox1.Text);
            }
            numPage.Value--;
            if (TextInfo.ContainsKey(numPage.Value))
            {
                textBox1.Text = TextInfo[numPage.Value];
            }
            else
            {
                textBox1.Text = "";
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
