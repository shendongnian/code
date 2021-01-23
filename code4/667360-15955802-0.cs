    foreach (var Field in db.A_Settings)
    {
        TextBox t = new TextBox();
        t.ID = Field.ID.ToString();
        t.CssClass = "smallinput";
        t.Text = Field.Text;
        //add literal control containing html that should appear before textbox
        LabelPlaceHolder.Controls.Add(new LiteralControl("html before"));
        LabelPlaceHolder.Controls.Add(t);
        //add literal control containing html that should appear after textbox
        LabelPlaceHolder.Controls.Add(new LiteralControl("html after"));
    }
