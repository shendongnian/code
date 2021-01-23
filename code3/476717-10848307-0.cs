     internal static ConnectionFactory newinstance()
        {
            try
            {
                return new   ConnectionFactory(ConfigurationManager.ConnectionStrings["myConString"].ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
