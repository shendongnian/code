    DataSet set = new DataSet("sites");
            DataTable table1 = new DataTable("site");
            table1.Columns.Add("SiteUrl");
            table1.Columns.Add("SiteTitle");
            
            // Create a DataSet and put both tables in it.
            using (SPSite TargetsiteCollection = new SPSite(InputSitecollectionUrl))
            {
                SPWebCollection allWebs = TargetsiteCollection.AllWebs;
                foreach (SPWeb web in allWebs)
                {
                    string WebUrl = web.Url;
                    string WebTitle = web.Title;
                    table1.Rows.Add(WebUrl, WebTitle);
                }
                set.Tables.Add(table1);
                
            }
            return set;
