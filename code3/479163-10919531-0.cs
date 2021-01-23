        protected void datalist1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // fetch values from the data bound row
                int identityID = e.Item.DataItem["columnname"];
                // Find your page control and assign values
                HtmlAnchor aBlogSbj = (HtmlAnchor)e.Item.FindControl("aBlogSbj");
                if (aBlogSbj != null)
                {
                    aBlogSbj.HRef=identityID;
                }
            }
        }
