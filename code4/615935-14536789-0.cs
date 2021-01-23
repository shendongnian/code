    for (int i = 0; i < this.Controls.Count; i++)
    {
       if (this.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
       this.Controls[i].Visible = False;
    }
