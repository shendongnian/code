    public void checkKey(object sender)
    {
        KeyEventArgs a = new KeyEventArgs(Keys.Back);
        if (sender.GetType().Name == "TextBox")
        {
            TextBox tb = (TextBox)sender;
            if ((a.KeyCode == Keys.Back && String.IsNullOrWhiteSpace(tb.Text)))
            {
                this.SelectNextControl(this.ActiveControl, false, true, true, true);
            }
        }
    }
