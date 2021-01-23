    Textbox myTxtbx = new Textbox();
    myTxtbx.Text = "Enter text here...";
    myTxtbx.GotFocus += GotFocus.EventHandle(RemoveText);
    myTxtbx.LostFocus += LostFocus.EventHandle(AddText);
    public RemoveText(object sender, EventArgs e)
    {
         myTxtbx.Text = "";
    }
    public AddText(object sender, EventArgs e)
    {
         if(String.IsNullOrWhiteSpace(myTxtbx.Text))
            myTxtbx.Text = "Enter text here...";
    }
