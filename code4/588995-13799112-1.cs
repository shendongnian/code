        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            list.Add("Januari");
            list.Add("Februari");
            list.Add("March");
            list.Add("April");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("August");
            list.Add("September");
            list.Add("Oktober");
            list.Add("November");
            list.Add("December");
            listBox1.Items.Clear();
            for (int index = 0; index < list.Count; index++)
            {
                listBox1.Items.Add(list[index]);
            }
        }
        private IList<string> list = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            int mnr = Convert.ToInt32(textBox1.Text);
            string mnm = Convert.ToString(listBox1.Items[mnr - 1]);
            textBox2.Text = mnm;
        }
