    Textbox myTxtbx = new Textbox();
    myTxtbx.Text = "Enter text here...";
    myTxtbx.GotFocus += GotFocus.EventHandle(RemoveText);
    myTxtbx.LostFocus += LostFocus.EventHandle(AddText);
    public void RemoveText(object sender, EventArgs e)
    {
        myTxtbx.Text = "";
    }
    public void AddText(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(myTxtbx.Text))
            myTxtbx.Text = "Enter text here...";
    }
