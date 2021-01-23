 
    public static class DatabaseExtensions
    {
        public static void PopulateCommandValues<T>(this Database db, 
            DbCommand cmd, T poco)
        {
            if (!db.SupportsParemeterDiscovery)
            {
                throw new InvalidOperationException("Database does not support parameter discovery");
            }
            db.DiscoverParameters(cmd);
            foreach (DbParameter parameter in cmd.Parameters)
            {
                if (parameter.Direction != System.Data.ParameterDirection.Output &&
                    parameter.Direction != System.Data.ParameterDirection.ReturnValue)
                {
                    PropertyInfo pi = poco.GetType().GetProperty(
                        parameter.ParameterName.Substring(1)); // remove @ from parameter
                    if (pi != null)
                    {
                        parameter.Value = pi.GetValue(poco, null);
                    }
                }
            }
        }
    }
