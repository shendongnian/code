        protected override void Page_Init()
        {
            this.rptr.ItemDataBound += new RepeaterItemEventHandler(rptr_ItemDataBound);
        }
        void rptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)e.Item;
            if (item.ItemType == ListItemType.Header)
            {
                HtmlTableCell thHidable = (HtmlTableCell)item.FindControl("thHidable");
                if (hideCondition)
                {
                    // thHidable.Visible = false; // do not render, not usable by client script (use this approach to prevent data from being sent to client)
                    thHidable.Style["display"] = "none"; // rendered hidden, can be dynamically shown/hidden by client script
                }
            }
            else if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableCell tdHideable = (HtmlTableCell)item.FindControl("tdHideable");
                if (hideCondition)
                {
                    // tdHideable.Visible = false; // do not render, not usable by client script (use this approach to prevent data from being sent to client)
                    tdHideable.Style["display"] = "none"; // rendered hidden, can be dynamically shown/hidden by client script
                }
            }
        }
