    using System;
    using System.Data;
    using Mono.Data.Sqlite;
    
    namespace test
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			IDbConnection conTemp = null;
    			IDbCommand cmdTemp = null;
    
    			conTemp = (IDbConnection)new SqliteConnection ("URI=file:/Users/userName/mnmh.db");
    			conTemp.Open ();
    			cmdTemp = conTemp.CreateCommand ();			
    			cmdTemp.CommandText = "SELECT * FROM employee";
    			IDataReader drTemp = cmdTemp.ExecuteReader ();
    			while (drTemp.Read()) {
    				Console.WriteLine (drTemp.GetString (0));
    			}
    			
    
    		}
    	}
    }
