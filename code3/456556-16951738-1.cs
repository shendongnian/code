            using (var db = new EF_DEMOEntities())
                  {
                       var cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandText = "[dbo].[proc_getmorethanonetable]";
                         try
                           {
                                db.Database.Connection.Open();
                                using (var reader = cmd.ExecuteReader())
                               {
                                     var orders =            
                                     ((IObjectContextAdapter)db).ObjectContext.Translate<Order>(reader);
                                     GridView1.DataSource = orders.ToList();
                                     GridView1.DataBind();
                                     reader.NextResult();
                                    var items =  
                               ((IObjectContextAdapter)db).ObjectContext.Translate<Item>(reader);
                                  GridView2.DataSource = items.ToList();
                                  GridView2.DataBind();
                                  
                                }
                            }
                           finally
                           {
                                db.Database.Connection.Close();
                           }
                           }
