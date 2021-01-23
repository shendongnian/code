      public static List<ActionItem> GetAllActions()
            {
                var actionItems = new List<ActionItem>();
                SqlDataReader actionsReader = CatalogDB.GetAllActions();
    
                try
                {
                    while (actionsReader.Read())
                    {
                        actionItems.Add(new ActionItem
                                            {
                                                Id = (int)actionsReader["Id"],
                                                Name = actionsReader["Name"] != DBNull.Value ? (string)actionsReader["Name"] : null,
                                                Description = (string)actionsReader["Description"],
                                                CreationDate = (DateTime)actionsReader["CreationDate"]                                                
                                            }
                            );
                    }
                }
                finally
                {
                    actionsReader.Close();
                }
    
                return actionItems;
            }
