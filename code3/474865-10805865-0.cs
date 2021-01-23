    for (int i = 0; i < fotos.Count(); i++)
    {
        if (File.Exists(Server.MapPath((fotos[i]))))
        {
            content_slider_inside.InnerHtml += @"<li id='img" + (i + 1).ToString() + "'><IMG SRC='" + fotos[i] + "' HEIGHT='490PX' /></li>";
            //navigation.InnerHtml += "<li id='item" + (i+1).ToString() + "' runat='server' class='menu_item'><a href='#img" + (i+1).ToString() + "'>" + (i+1).ToString() + "</a></li>";
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes["href"] = "#img" + (i+1).ToString();
            a.InnerHtml = (i + 1).ToString();
                        
            HtmlGenericControl c = new HtmlGenericControl("li");
            c.ID = "item" + (i+1).ToString();
            c.Attributes["runat"] = "server";
            c.Attributes["class"] = "menu_item";
            c.Controls.Add(a);
            navigation.Controls.Add(c);
            id_imgs.Add("img" + (i+1).ToString());
            id_items.Add("item" + (i+1).ToString());
        }
    }
