     var sqlBuilder = new SqlConnectionStringBuilder
              {
                DataSource = "myServer",
                InitialCatalog = "mydatabase",
                IntegratedSecurity = false,
                UserID = "user",
                Password = "pass",
                MultipleActiveResultSets = true //<-- here
              };
