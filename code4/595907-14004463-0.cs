    for (int i = 0; i < this.Controls.Count; i++)
    {
        if (this.Controls[i] is TextBox)
        {
            this.Controls[i].Text = "";
        }
    }
