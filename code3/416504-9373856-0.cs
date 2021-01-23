    using System;
    using System.Runtime.InteropServices;
    
    public class ODBC_Manager
    {
    	[DllImport("ODBCCP32.dll")]
    	public static extern bool SQLConfigDataSource(IntPtr parent, int request, string driver, string attributes);
    	
    	[DllImport("ODBCCP32.dll")]
    	public static extern int SQLGetPrivateProfileString(string lpszSection, string lpszEntry, string lpszDefault, string @RetBuffer, int cbRetBuffer, string lpszFilename);
    
    	private const short ODBC_ADD_DSN = 1;
    	private const short ODBC_CONFIG_DSN = 2;
    	private const short ODBC_REMOVE_DSN = 3;
    	private const short ODBC_ADD_SYS_DSN = 4;
    	private const short ODBC_CONFIG_SYS_DSN = 5;
    	private const short ODBC_REMOVE_SYS_DSN = 6;
    	private const int vbAPINull = 0;
    
    	public void CreateDSN(string strDSNName)
    	{
    		string strDriver;
    		string strAttributes;
    
    		try
    		{
    			string strDSN = "";
    
    			string _server = //ip address of the server
    			string _user = //username
    			string _pass = //password
    			string _description = //not required. give a description if you want to
    
    
    			strDriver = "iSeries Access ODBC Driver";
    
    			strAttributes = "DSN=" + strDSNName + "\0";
    			strAttributes += "SYSTEM=" + _server + "\0";
    			strAttributes += "UID=" + _user + "\0";
    			strAttributes += "PWD=" + _pass + "\0";
    
    			strDSN = strDSN + "System = " + _server + "\n";
    			strDSN = strDSN + "Description = " + _description + "\n";
    
    			if (SQLConfigDataSource((IntPtr)vbAPINull, ODBC_ADD_SYS_DSN, strDriver, strAttributes))
    			{
    				Console.WriteLine("DSN was created successfully");
    			}
    			else
    			{
    				Console.WriteLine("DSN creation failed...");
    			}
    		}
    		catch (Exception ex)
    		{
    			if (ex.InnerException != null)
    			{
    				Console.WriteLine(ex.InnerException.ToString());
    			}
    			else
    			{
    				Console.WriteLine(ex.Message.ToString());
    			}
    		}
    	}
    
    	public int CheckForDSN(string strDSNName)
    	{
    		int iData;
    		string strRetBuff = "";
    		iData = SQLGetPrivateProfileString("ODBC Data Sources", strDSNName, "", strRetBuff, 200, "odbc.ini");
    		return iData;
    	}
    }
