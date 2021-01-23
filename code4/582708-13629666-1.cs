     using (SPSite site = new SPSite(url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList lists = web.Lists["list name"];
                        foreach (SPListItem itemin lists.Items)
                        {
                           string test = Convert.ToString( item["test"]);
                            TextBox1.Text = test;
    
                        }
                    }
                 }
