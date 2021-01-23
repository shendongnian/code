    foreach (var Field in db.A_Settings)
    {
        TextBox t = new TextBox();
        t.ID = Field.ID.ToString();
        t.CssClass = "smallinput";
        t.Text = Field.Text;
    
        var label = new HtmlGenericControl("label");
        label.Controls.Add(new LiteralControl("LABEL TEXT"));
    
        var p = new HtmlGenericControl("p");
        p.Controls.Add(label);
    
        var span = new HtmlGenericControl("span");
        span.Attributes.Add("class", "field");
        span.Controls.Add(t);
        p.Controls.Add(span);
    
        LabelPlaceHolder.Controls.Add(p);
    }
