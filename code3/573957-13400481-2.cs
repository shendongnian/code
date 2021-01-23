        void DeleteByDate()
        {
            try
            {
                using (OleDbConnection dbConnection = new OleDbConnection())
                {
                    dbConnection.ConnectionString = myConnectionString;
                    dbConnection.Open();
                    string dt = string.Format("{0}/{1}/{2}", 14, 07, 2012);
                    using (OleDbCommand command = new OleDbCommand("DELETE FROM tblList WHERE lisDate = [pDate]", dbConnection))
                    {
                        OleDbParameter dateParm = command.Parameters.Add("pDate", OleDbType.DBTimeStamp);
                        dateParm.Value = dt;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
