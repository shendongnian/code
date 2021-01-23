     private void UpdateConnectionString(string ConfigPath)
     {
         XmlDocument xmlDocument = new XmlDocument();
         xmlDocument.Load(ConfigPath);
          XmlNode parentNode = xmlDocument.DocumentElement;
         if (parentNode.Name == "connectionStrings")
         {
            foreach (XmlNode childNode in parentNode.ChildNodes)
            {
               if (childNode.Name == "add" && childNode.Attributes["name"].Value=="Punch_Uploader.Properties.Settings.testConnectionString")
               {
                 string sqlConnectionString =childNode.Attributes["connectionString"].Value;
                 SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(sqlConnectionString);
                 sqlBuilder.InitialCatalog = "yourDatabaseName";
                 sqlBuilder.IntegratedSecurity = true;
                 sqlBuilder.Password = "";
           
                 //Change any other attributes using the sqlBuilder object
                 childNode.Attributes["connectionString"].Value = sqlBuilder.ConnectionString;
               }
            }
          }
          xmlDocument.Save(ConfigPath);
      }
