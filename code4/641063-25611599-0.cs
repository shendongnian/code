        public static void ClearDatabase<T>() where T : DbContext, new()
        {
            using (var context = new T())
            {
                var tableNames = context.Database.SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%'").ToList();
                foreach (var tableName in tableNames)
                {
                    foreach (var t in tableNames)
                    {
                        try
                        {
                            if (context.Database.ExecuteSqlCommand(string.Format("TRUNCATE TABLE [{0}]", tableName)) == 1)
                                break;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                context.SaveChanges();
            }
        }
