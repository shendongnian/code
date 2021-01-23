        BindingList<Person> bl;
        public Form1()
        {
            InitializeComponent();
            bl = new BindingList<Person>();
            dataGridView1.DataSource = bl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Person p = new Person();
                p.Name = textBox1.Text;
                bl.Add(p);
                textBox1.Text = "";
                textBox1.Focus();
            }
        }    
