        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateTextBox();
            // other thing if you want
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateTextBox();
            // other thing if you want
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateTextBox();
            // other thing if you want
        }
        private void UpdateTextBox()
        {
            if (this.checkBox1.Checked == true)
            {
                String value = String.Empty;
                if (this.radioButton1.Checked == true)
                {
                    value = this.radioButton1.Text;
                }
                else if (this.radioButton2.Checked == true)
                {
                    value = this.radioButton2.Text;
                }
                // and so ....
                this.textBox1.Text = value;
            }
            else
            {
                this.textBox1.Text = String.Empty;
            }
        }
