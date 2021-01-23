        //global var
        TextBox currentTB = null;
        private void button1_Click(object sender, EventArgs e)
        {
            inputPanel1.Enabled = !inputPanel1.Enabled;
            if(currentTB!=null)
                currentTB.Focus();
        }
        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            currentTB = (TextBox)sender;
        }
