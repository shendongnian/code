            using (SPSite site = new SPSite("SiteUrl"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    web.AllowUnsafeUpdates = true;
                    //documentCategories is list of doc library names on SPSite, so catName  could be something like "Invoices"
                    foreach (string catName in documentCategories)
                    {
                        SPFolder folder = GetFolder(web, catName, processInstanceId, false);
                        if (folder.Exists)
                        {
                            //handle specific document...
                            foreach (SPFile file in folder.Files)
                            {
                                
                            }
                        }
                    }
                    web.Close();
                    web.Dispose();
                }
                site.Close();
                site.Dispose();
            }
