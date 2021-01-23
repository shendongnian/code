    private void Panel1_ControlAdded(object sender, ControlEventArgs e)
    {
        var tb = e.Control as TextBox;
        if (tb != null)
        {
            tb.LostFocus += new EventHandler(TextBox_LostFocus);
        }
    }
