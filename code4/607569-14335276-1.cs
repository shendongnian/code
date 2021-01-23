    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var item = (Article)e.Item.DataItem;
                    if (item.Title != null)
                        ((HtmlAnchor)e.Item.FindControl("aTitle")).InnerText = item.Title;
                    if (item.Country != null)
                    {
                        if (item.Country.Length > 0)
                            ((Literal)e.Item.FindControl("litCountry")).Text = item.Country + " ,";
                    }
                    ((Literal)e.Item.FindControl("litTime")).Text = item.CreationDate.ToString();
    
                }
            }
