        Encripter enc = new Encripter();
        string strconfig = u.readFile(u.ubicacionActual() + "\\conn.config");
        DBCon dbcon = JsonConvert.DeserializeObject<DBCon>(enc.decrypt(strconfig));
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        EntityConnectionStringBuilder efb = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings["ProyectEntities"].ConnectionString);
        SqlConnectionStringBuilder sqb = new SqlConnectionStringBuilder(efb.ProviderConnectionString);
        // Now we can set the datasource
        sqb.DataSource = dbcon.datasource;
        sqb.InitialCatalog = dbcon.catalog;
        sqb.UserID = dbcon.user;
        sqb.Password = dbcon.password;
        efb.ProviderConnectionString = sqb.ConnectionString;
        // to rewrite the app.config!
        ChangeEFConnectionString("ProyectEntities", efb.ProviderConnectionString);
        ProyectEntities db = new ProyectEntities(); // dbcontext
