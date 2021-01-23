        public static void RunSqlCommandText(string connectionString, string commandText) {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = conn.CreateCommand();
            try {
                comm.CommandType = CommandType.Text;
                comm.CommandText = commandText;
                comm.Connection = conn;
                conn.Open();
                comm.ExecuteNonQuery();
            } catch (Exception ex) {
                System.Diagnostics.EventLog el = new System.Diagnostics.EventLog();
                el.Source = "Sites event handler";
                el.WriteEntry(ex.Message + ex.StackTrace + " SQL '" + commandText + "'");
            } finally {
                conn.Close();
                comm.Dispose();
            }
        }
        public static int RunSqlAndReturnId(string connectionString, string commandText) {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = conn.CreateCommand();
            int id = -1;
            try {
                comm.CommandType = CommandType.Text;
                comm.CommandText = commandText;
                comm.Connection = conn;
                conn.Open();
                var returnvalue = comm.ExecuteScalar();
                if (returnvalue != null) {
                    id = (int)returnvalue;                
                }
            } catch (Exception ex) {
                System.Diagnostics.EventLog el = new System.Diagnostics.EventLog();
                el.Source = "Sites event handler";
                el.WriteEntry(ex.Message + ex.StackTrace + " SQL '" + commandText + "'");
            } finally {
                conn.Close();
                comm.Dispose();
            }
            return id;
        }
