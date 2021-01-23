        public DataTable GetData(string commandString)
        {
            var result = new DataTable();
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["_uniManagementConnectionString1"].ConnectionString))
                using (var cmd = new SqlCommand(commandString, cn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(result);
                    }
            return result;
        }
