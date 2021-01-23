    private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox2.Enter += new EventHandler(textBox2_Enter); 
            this.textBox2.Leave += new EventHandler(textBox2_Leave);
            textBox2_SetText();
        }
        protected void textBox2_SetText()
        {
            this.textBox2.Text = "Default Text...";
            textBox2.ForeColor = Color.Gray;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Black)
                return;
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
                textBox2_SetText();
        }
