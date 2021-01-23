        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "a", "b", "c" });//fill comboBox your way on a loading time
        }
        public void UpdatingControls(string a, string b)
        {
            textBox1.Text = a;
            comboBox1.SelectedText = b;
        }
        //on form2;
        Form1 f2;
        private void OpenForm2Button_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.UpdatingControls("a", "b"); //a will go into textBox, b will be choosen in comboBox
        }
