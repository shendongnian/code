        for (int i = 0; i < 3; i++)
        {
            HtmlGenericControl listItem = new HtmlGenericControl("li");
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            Image im = new Image();
            //im.ImageUrl = ds.Tables[0].Rows[1].ItemArray.ToString();
            anchor.Attributes.Add("href", "");
            anchor.Controls.Add(im);
            anchor.InnerText = "TabX";
            
            list.Controls.Add(anchor);
         }
