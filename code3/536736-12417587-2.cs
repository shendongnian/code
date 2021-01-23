    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(MessageBox.Show("Exit or no?",
                           "My First Application",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.No) {
            e.Cancel = true;
        }
    }
