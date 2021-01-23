    using (DbContext context = new DbContext("DBConnectionStringNameFromAppConfig"))
                {
    
                    SqlParameter[] parameters =
                          {
                                            new SqlParameter("@OwnerID", DBNull.Value),
                                            new SqlParameter("@ExternalColorID", colorOwner.ExternalColorID),
                                            new SqlParameter("@ProductionSiteID", DBNull.Value),
                                            new SqlParameter("@PanelstatusNr", DBNull.Value),
                                            new SqlParameter("@DateLastChecked", DBNull.Value),
                                            new SqlParameter("@rowcount", DBNull.Value),
                          };
                    var colors = context.Database.SqlQuery<Models.ColorSelectEvaluation>("[dbo].[sp_Color_Select_Evaluation] @OwnerID, @ExternalColorID, @ProductionSiteID, @PanelstatusNr, @DateLastChecked, @rowcount", parameters).ToList();
    
                }
