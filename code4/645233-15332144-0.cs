        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string singleByteString = Encoding.Default.GetString(Encoding.Default.GetBytes(inputText));
            textBox2.Text = singleByteString;
            textBox3.Text = inputText;
        }
