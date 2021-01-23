    for (Int32 i = 0; i < 2; i++)
    {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = i.ToString();
            div.InnerHtml = i.ToString();
            showdiv.Controls.Add(div);
    }
