        private void okBtn_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(textBox1.Text, @"^[a-zA-Z0-9]+$");
            if (match.Success)
            {
                fm1.txtFileName = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Filename cannot include illegal characters.");
            }
        }
