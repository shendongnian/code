    namespace DataSet1TableAdapters
    {
        public partial class menu_widac_wszystkoTableAdapter
        {
        	public List<int> GetIdList()
        	{
        		List<int> list = new List<int>();
        		System.Data.SqlClient.SqlCommand command = this.CommandCollection(0);
        		command.CommandTimeout = command.Connection.ConnectionTimeout;
        
        		System.Data.ConnectionState previousConnectionState = command.Connection.State;
        		try {
        			if (((command.Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open)) {
        				command.Connection.Open();
        			}
        			using (System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader()) {
        				while (reader.Read()) {
        					list.Add(reader.GetInt32(0));
        				}
        			}
        		} finally {
        			if ((previousConnectionState == System.Data.ConnectionState.Closed)) {
        				command.Connection.Close();
        			}
        		}
        
        		return list;
        	}
        }
    }
