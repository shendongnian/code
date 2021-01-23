    private void label7_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
           Application.Exit();
        }
    }
    label7.Click += label7_Click;
