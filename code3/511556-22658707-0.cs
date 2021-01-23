                using (DAL.projectEntities en = new DAL.projectEntities())
                {
                    foreach (var item in en.tableName.Where(a => a.tableName != null).ToList())
                    {
                        itemsList.Add(item.tableFieldName);
                    }                                   
                }
                comboboxTable.ItemsSource = itemsList;
