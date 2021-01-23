    public MyForm : Form {
        public MyForm(){
            InitializeComponents();
            // Here you define what TextBoxes should react on user input
            textBox8.TextChanged += TextChanged;
            textBox10.TextChanged += TextChanged;
        }
        private void TextChanged(object sender, EventArgs e)
        {
            int val1;
            int val2;
            if (!int.TryParse(textBox8.Text, out val1) || !int.TryParse(textBox10.Text, out val2))
                return;
            Int32 val3 = val1 * val2;
            // Here you define what TextBox should show the multiplication result
            textBox7.Text = val3.ToString();
        }
    }
