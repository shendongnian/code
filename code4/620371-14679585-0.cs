    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    
    // for OleDB (Access, VFP, etc)
    using System.Data.OleDb;
    // for SQL-Server
    using System.Data.SqlClient;
    
    namespace DataMgmt
    {
    	public class MyConnection
    	{
    		// no matter the connection to server, it will require some "handle"
    		// that is of type "IDbConnection"
    		protected IDbConnection sqlConnectionHandle;
    
    		// when querying, ANY query could have an exception that needs to have
    		// possible further review for handling
    		public Exception LastException
    		{ get; protected set; }
    
    		// When calling an execute command (select, insert, update, delete), 
    		// they all can return how many rows affected
    		public int RowsAffectedByQuery
    		{ get; protected set; }
    
    		// different databases could have different connection strings. Make
    		// virtual and throw exception so sub-classed must return proper formatted.
    		public virtual string GetConnectionString()
    		{ throw new Exception("GetConnectionString() method must be overridden."); }
    
    		// each has its own "IDbConnection" type too
    		protected virtual IDbConnection SQLConnectionHandle()
    		{ return sqlConnectionHandle; }
    
    		public virtual IDbCommand GetSQLDbCommand()
    		{ throw new Exception("GetSQLDbCommand() method must be overridden."); }
    
    		// generic routine to get a data parameter...
    		public virtual IDbDataParameter AddDbParmSpecificValue(string ParmName, object UnknownValue)
    		{ throw new Exception("AddDbParmSpecificValue() method must be overwritten per specific connection."); }
    
    		// generic "Connection" since they are all based on IDbCommand...
    		public override bool SQLConnect()
    		{
    			// pre-blank exception in case remnant from previous activity
    			LastException = null;
    
    			if (sqlConnectionHandle.State != System.Data.ConnectionState.Open)
    				try
    				{
    					// if not open, always make sure we get updated connection string
    					// if ever changed by some other "unknown" condition...
    					sqlConnectionHandle.ConnectionString = GetConnectionString();
    					sqlConnectionHandle.Open();
    				}
    				catch (Exception ex)
    				{
    					// Preserve in generic sqlException" property for analysis OUTSIDE this function
    					LastException = ex;
    				}
    
    			// if NOT connected, display message to user and set error code and exception
    			if (sqlConnectionHandle.State != System.Data.ConnectionState.Open)
    				LastException = new Exception("Unable to open database connection.");
    
    			// return if it IS successful at opening the connection (or was already open)
    			return sqlConnectionHandle.State == System.Data.ConnectionState.Open;
    		}
    
    		// likewise disconnect could be common
    		public void SQLDisconnect()
    		{
    			if (sqlConnectionHandle != null)
    				if (sqlConnectionHandle.State == ConnectionState.Open)
    					sqlConnectionHandle.Close();
    		}
    
    
    		public bool SqlExecNonQuery( IDbCommand SQLCmd, DataTable oTbl)
    		{
    			// pre-clear exception
    			LastException = null;
    
    			// fill the table...
    			SQLConnect();
    			try
    			{
    				RowsAffectedByQuery = SQLCmd.ExecuteNonQuery();
    			}
    			catch (Exception e)
    			{
    				LastException = e;
    				throw e;
    			}
    			finally
    			{
    				SQLDisconnect();
    			}
    
    			// Its all ok if no exception error
    			return LastException == null;
    		}
    	
    	}
    
    	
    	// Now, build your connection manager per specific type
    	public class MyAccessConnection : MyConnection
    	{
    		public MyAccessConnection()
    		{	sqlConnectionHandle =  new OleDbConnection();	}
    
    		public override string GetConnectionString()
    		{	return "Your Connection String from AppSettings.. any changes if OleDb vs SQL";	}
    		
    		public override IDbCommand GetSQLDbCommand()
    		{	return new OleDbCommand( "", (OleDbConnection)sqlConnectionHandle ); }
    
    		public override IDbDataParameter AddDbParmSpecificValue(string ParmName, object UnknownValue)
    		{	return new OleDbParameter( ParmName, UnknownValue );	}
    
    	}
    
    	public class MySQLConnection : MyConnection
    	{
    		public MySQLConnection()
    		{	sqlConnectionHandle = new SqlConnection();  }
    
    		public override string GetConnectionString()
    		{ return "Your Connection String from AppSettings... any alterations needed??? "; }
    
    		public override IDbCommand GetSQLDbCommand()
    		{ return new SqlCommand ("", (SqlConnection)sqlConnectionHandle); }
    
    		public override IDbDataParameter AddDbParmSpecificValue(string ParmName, object UnknownValue)
    		{ return new SqlParameter(ParmName, UnknownValue); }
    	}
    
    	// Now to implement... pick one... Access or SQL-Server for derivation...
    	public class MyDataLayer : MyAccessConnection
    	{
    		public void SomeSQLCall()
    		{
    			IDbCommand sqlcmd = GetSQLDbCommand();
    			sqlcmd.CommandText = "UPDATE TileTypes SET Title = @Title, "
    								+ "Picture = @Picture, "
    								+ "Color = @Color "
    								+ "WHERE ID = @ID";
    			sqlcmd.Parameters.Add( AddDbParmSpecificValue( "@Title", titleTextBox.Text.Trim() ));
    			sqlcmd.Parameters.Add( AddDbParmSpecificValue( "@Picture", typePictureBox.ImageLocation) );
    			sqlcmd.Parameters.Add( AddDbParmSpecificValue( "@Color", colorButton.BackColor.ToArgb()) );
    			sqlcmd.Parameters.Add( AddDbParmSpecificValue(  "@ID", id));
			if( SqlExecNonQuery(sqlcmd))
				// Good to go
				DoSomethingWithTheData;
			else
				// Notify of whatever error thrown....
    		}
    	}
    }
