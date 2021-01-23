     using (SPSite site = new SPSite(url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList lists = web.Lists["list name"];
                        foreach (SPField field in lists.Fields)
                        {
                            Literal1.Text += field.Title + "</br>";
    
                        }
                    }
                 }
