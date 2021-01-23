    foreach(WebControl c in Page.Controls)
    {
        if(c is TextBox || c is DropdownList)
        {
            c.Enabled = false;
        }
     }
