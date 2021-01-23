    foreach(Control c in parentControlIdOrName.Controls)
    {
        if(c.GetType()==typeof(TextBox))
        {
            if(((TextBox)c).Name.indexOf("textbox")!=-1)
            {
                // do your coding here...what ever you want....
            }
        }
    }
