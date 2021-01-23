    private void Button1_Click(object sender, EventArgs e)
    {
        using (var dialog = new Form2())
        {
            this.Enable = false;
            dialog.ShowDialog();
            this.Enable = true;
        }
    }
