    Textbox myTxtbx = new Textbox();
    myTxtbx.Text = "Enter text here...";
    myTxtbx.OnFocus += OnFocus.EventHandle(RemoveText);
    myTxtbx.LoseFocus += LoseFocus.EventHandle(AddText);
    public RemoveText(object sender, EventArgs e)
    {
         myTxtbx.Text = "";
    }
    public AddText(object sender, EventArgs e)
    {
         if(String.IsNullOrWhitespace(myTxtbx.Text))
            myTxtbx.Text = "Enter text here...";
    }
