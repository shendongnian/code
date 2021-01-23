    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(
                delegate
                {
            SqlConnection Connection = Helpers.ConnectionHelper.CreateConnection();
            SqlCommand cmd = new SqlCommand("MarkNotificationRead", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.id;
            Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
            }
            Connection.Close();
                }));
