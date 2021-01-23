        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (properties.ListTitle.Equals("cl2"))
            {
                using (SPSite site = properties.OpenSite())
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        string sytr = web.Url.ToString();
                        string s = web.PortalUrl.ToString();
                        string sq = web.ServerRelativeUrl.ToString();
                        string str = site.Url.ToString();
                        SPListItem _currentItem = properties.ListItem;
                        cItem["Title"] = "Test";
                        cItem.Update();
                        base.ItemAdded(properties);
                    }
                }
            }
        }
