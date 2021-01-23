     HtmlGenericControl div = (HtmlGenericControl)Page.FindControl("<<div id>>");
     HtmlGenericControl ul = HtmlGenericControl("ul")
     HtmlGenericControl liToAdd = null;
     HtmlGenericControl linkToAdd = null;
            for (int i = 0; i < 10; i++)
            {
                liToAdd = new HtmlGenericControl("li");
                linkToAdd = new HtmlGenericControl("a");
                linkToAdd.InnerText = "demo";
                linkToAdd.Attributes.Add("href", "");
                liToAdd.Controls.Add(linkToAdd);
                ul.Controls.Add(liToAdd);
    
    
            }
                div.Controls.Add(ul);
