    label_click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", 
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            this.Close();
        }
    }
