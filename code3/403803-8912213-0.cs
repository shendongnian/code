    public void RssFeedItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl listControl = (HtmlGenericControl)e.Item.FindControl("socialListItem");
                if (listControl != null)
                {
                    if (!ShowSource)
                    {
                        HtmlGenericControl spanControl = (HtmlGenericControl)listControl.FindControl("source");
                        spanControl.Visible = false;
                    }
                    listControl.Attributes["class"] += ((XmlFeedItem)e.Item.DataItem).XmlFeedType;
                }
            }
        }
