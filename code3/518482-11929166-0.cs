        public static MyEntities NewContext()
        {
            var y = new System.Data.EntityClient.EntityConnectionStringBuilder();
            y.Provider = "System.Data.SqlClient";
            string conn = CodeToGetConnectionStringHere();
            if(!conn.EndsWith(";")) conn += ";";
            conn += "MultipleActiveResultSets=true";
            y.ProviderConnectionString = conn;
            y.Metadata = "res://*/MyModel.csdl|res://*/MyModel.ssdl|res://*/MyModel.msl";
            return new MyEntities(y.ConnectionString);
        }
