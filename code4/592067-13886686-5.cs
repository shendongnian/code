     protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
     {
            var divImg = (HtmlGenericControl)e.Item.FindControl("divImg");
            divImg.Style.Add("background-color", "#ffeee5"); 
     }
