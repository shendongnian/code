    for (Int32 i = 0; i < 2; i++)
    {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = i.ToString();
            div.InnerHtml = i.ToString();
            div.ClientIDMode = ClientIDMode.Static; //this is for .NET 4.5 only. Required to have ClientID the same as ID.
            showdiv.Controls.Add(div);
    }
