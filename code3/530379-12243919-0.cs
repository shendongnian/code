    foreach (var w in wl.ToList())
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        li.Attributes.Add("class", "ui-widget-content");
        li.InnerText = w.FirstName;
        selectable.Controls.Add(li);
    }
