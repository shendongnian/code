                        IQueryable<DataBase.Models.UserInfo> query = null;
                        using (var context = new HealthFamilyContext(false))
                        {
                            query = from p in context.UserInfoes where p.Id == 1 select p;
                        }
                        using (var context = new HealthFamilyContext(false))
                        {
                            QueryHelper.SetInternalContextOfQuery(query, context);
                            var data = query.ToList();
                        }
