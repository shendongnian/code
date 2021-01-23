    private void Button1_Click(object sender, EventArgs e)
    {
        using (var dialog = new Form2())
        {
            this.Enabled = false;
            dialog.ShowDialog();
            this.Enabled = true;
        }
    }
