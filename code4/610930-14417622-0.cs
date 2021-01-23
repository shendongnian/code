    foreach(var item in this.Controls)
    {
        if (item is Button)
        {
            item.Enabled = true;
            item.Text = "";
            item.BackColor = default(Color);
        }
    }
