    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    
    public class DataAccess
    {
    
    
    	#region "Public Methods"
    
    	public static DataTable GetTableFromQuery(string query, Dictionary<string, object> parameters, CommandType commandType)
    	{
    		DataTable dataTable = new DataTable();
    		using (OleDbConnection conn = GetConnection()) {
    			using (OleDbCommand cmd = new OleDbCommand(query, conn)) {
    				cmd.CommandType = commandType;
    				if (parameters != null) {
    					foreach (KeyValuePair<string, object> parameter in parameters) {
    						cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
    					}
    				}
    				using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd)) {
    					adapter.Fill(dataTable);
    				}
    			}
    		}
    		return dataTable;
    	}
    
    	public static object GetSingleObjectFromQuery(string query, Dictionary<string, object> parameters, CommandType commandType)
    	{
    		object value = null;
    		using (OleDbConnection conn = GetConnection()) {
    			using (OleDbCommand cmd = new OleDbCommand(query, conn)) {
    				cmd.CommandType = commandType;
    				if (parameters != null) {
    					foreach (KeyValuePair<string, object> parameter in parameters) {
    						cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
    					}
    				}
    				conn.Open();
    				using (OleDbDataReader reader = cmd.ExecuteReader()) {
    					while (reader.Read()) {
    						value = reader.GetValue(0);
    					}
    				}
    			}
    		}
    		return value;
    	}
    
    	public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters, CommandType commandType)
    	{
    		int value = 1;
    		using (OleDbConnection conn = GetConnection()) {
    			using (OleDbCommand cmd = new OleDbCommand(query, conn)) {
    				cmd.CommandType = commandType;
    				if (parameters != null) {
    					foreach (KeyValuePair<string, object> parameter in parameters) {
    						cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
    					}
    				}
    				cmd.Connection.Open();
    				value = cmd.ExecuteNonQuery();
    			}
    		}
    		return value;
    	}
    
    	#endregion
    
    	#region "Private Methods"
    
    	private static OleDbConnection GetConnection()
    	{
    		string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString;
    		return new OleDbConnection(ConnectionString);
    	}
    
    	#endregion
    
    }
