     public IEnumerable<Item> Items
        {
            get
            {
                using (var context = new CatalogueContext())
                {
                    var ids = context.Database.SqlQuery<int>("SELECT Item_Id FROM CategoryItems WHERE Category_Id = " +
                                                             this.Id + " ORDER BY Position");
                    foreach (int id in ids)
                        yield return context.Items.Find(id);
                            
                }
            }
        } 
