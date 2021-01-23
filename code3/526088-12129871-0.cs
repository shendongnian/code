        public Form1()
        {
           InitializeComponent();
           textBox1.Validated += new EventHandler(textBox_Validated);
           textBox2.Validated += new EventHandler(textBox_Validated);
           textBox3.Validated += new EventHandler(textBox_Validated);
           ...
           textBox10.Validated += new EventHandler(textBox_Validated);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
        }
        public void textBox_Validated(object sender, EventArgs e)
        { 
            var tb = (TextBox)sender;
            if(string.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "error");
            }
        }
