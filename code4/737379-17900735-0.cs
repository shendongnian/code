    public string GetSomethingFromID(string ID)
        {
            try
            {
                string cmdString = "SELECT columnName FROM tableName WHERE ID='" + ID + "'";
                SqlConnection con = new SqlConnection(connectionString);  // create your connection string and write it's name.
                con.Open();
                SqlCommand command = new SqlCommand(cmdString, con);
                SqlDataReader sdr = command.ExecuteReader();
                sdr.Read();
                string something = sdr[0].ToString();
                con.Close();
                return something;
            }
            catch
            {
                return null;
            }
        }
