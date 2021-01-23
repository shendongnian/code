     Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        System.Console.WriteLine("Starting to write app.config stuff");
        //Change the Admin's app.config where name=companyProductionEntities
        config.ConnectionStrings.ConnectionStrings["companyProductionEntities"].ConnectionString =
            string.Format(@"metadata=res://*/DataAccess.companyEntities.csdl|res://*/DataAccess.companyEntities.ssdl|res://*/DataAccess.companyEntities.msl;provider=System.Data.SqlClient;provider connection string=';data source={0};initial catalog=companyProduction;integrated security=True;multipleactiveresultsets=True;App=EntityFramework';", SeleniumConfiguration.SimpleDatabaseConnectionString);
        config.Save(ConfigurationSaveMode.Modified, true);
        ConfigurationManager.RefreshSection("connectionStrings");
