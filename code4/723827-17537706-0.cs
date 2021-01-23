        public void AddServer(string name)
        {
            if (!context.Servers.Any(c => c.Name == name))
            {
                context.Database.ExecuteSqlCommand(@"MERGE Servers WITH (HOLDLOCK) AS T
                                                     USING (SELECT {0} AS Name) AS S
                                                     ON T.Name = S.Name
                                                     WHEN NOT MATCHED THEN 
                                                     INSERT (Name) VALUES ({0});", name);
            }
        }
