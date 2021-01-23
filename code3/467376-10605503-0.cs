    using System;
    using System.Data;
    using System.Data.OleDb;
    
    public static class Program
    {
    	///This is a very basic example of how to use OleDb objects to edit spreadsheets.
    	/// For more advanced operations, look into using OleDb with DataSets/DataTables.
    	public static void Main(string[] args)
    	{
    		string Filename = "C:\\test.xls";
    		//If you are using xls format, use this connection string.
    		string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Filename + ";Extended Properties=\"Excel 8.0;HDR=NO;\"";
    		//If you are using xlsx format, use this connection string.
    		//string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Filename + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
    		
    		string Name_Value = "First Name";
    		string Surname_Value = "Surname";
    		
    		string SQL1 = "UPDATE [Sheet1$A2:A2] SET F1='" + Name_Value + "'";
    		string SQL2 = "UPDATE [Sheet1$B2:B2] SET F1='" + Surname_Value + "'";
    		
    		using(OleDbConnection Connection = new OleDbConnection(ConnectionString))
    		{
    			Connection.Open();
    			using(OleDbCommand cmd1 = new OleDbCommand(SQL1,Connection))
    			{
    				cmd1.ExecuteNonQuery();
    			}
    			using(OleDbCommand cmd2 = new OleDbCommand(SQL2,Connection))
    			{
    				cmd2.ExecuteNonQuery();
    			}
    		}
    	}
    }
