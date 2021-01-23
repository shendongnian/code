    protected void repSubItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var fieldRenderer1 = e.Item.FindControl("FieldRenderer1") as Sitecore.Web.UI.WebControls.FieldRenderer;
            if (fieldRenderer1 != null)
            {
                fieldRenderer1.Style["Width"] = MyCoolWidth;
            }
        }
    }
