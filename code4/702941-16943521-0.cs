     public DistributionSSEntities Connection()
        {
            string ConString = "SERVER=192.168.1.100;DATABASE=DistributionSS;UID=sa;PASSWORD=125;";
            SqlConnectionStringBuilder SCB= new SqlConnectionStringBuilder(ConString);
            //------------------------
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();
            builder.Metadata = "res://*/Model.Model.csdl|res://*/Model.Model.ssdl|res://*/Model.Model.msl";
            builder.Provider = "System.Data.SqlClient";
            builder.ProviderConnectionString = SCB.ConnectionString;
            DistributionSSEntities db = new DistributionSSEntities(builder.ToString());
            return db;
        }
