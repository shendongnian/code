    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Match matches = Regex.Matches(input, @"(?<=\[)[A-Za-z]+(?=\])")
            if(!matches.Success)
            {
            MessageBox.Show("Invalid input.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox1.Text = "";
            }
        }
