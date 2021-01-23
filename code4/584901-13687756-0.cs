    protected void ItemBound(Object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null) return;
            HtmlGenerics body = (HtmlGenerics)e.Item.FindControl("myLegend");
            body.InnerText = "Foo";
        }
