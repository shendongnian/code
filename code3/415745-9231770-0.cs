    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Would you like to exit the program?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            e.Cancel = true;
    }
