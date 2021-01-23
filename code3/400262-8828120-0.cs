        public bool ExecutePackage(string jobName)
        {
            int result = -1;
            bool success = false;
            try
            {
                // "SsisConnectionString" will be the name of your DB connection string in your config
                Database db = DatabaseFactory.CreateDatabase("SsisConnectionString");  
                using (DbCommand dbCommand = db.GetStoredProcCommand("sp_start_job"))
                {
                    db.DiscoverParameters(dbCommand);
                    db.SetParameterValue(dbCommand, "job_name", jobName);
                    db.SetParameterValue(dbCommand, "job_id", null);
                    db.SetParameterValue(dbCommand, "server_name", null);
                    db.SetParameterValue(dbCommand, "step_name", null);
                    db.ExecuteNonQuery(dbCommand);
                    result = Convert.ToInt32(db.GetParameterValue(dbCommand, "RETURN_VALUE"));
                }
            }
            catch (Exception exception)
            {
                success = false;
            }
            switch (result)
            {
                case 0:
                    success = true;
                    break;
                default:
                    success = false;
                    break;
            }
            return success;
        }
