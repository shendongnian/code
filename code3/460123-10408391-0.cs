    // Compile with: csc foo.cs /r:System.Management.dll
    using System;
    using System.Management;
    
    namespace Foo
    {
    	public class Program
    	{
    		private int getDatabaseFileSize(string DSADatabaseFile, string machineName)
    		{
    		    string scope = @"\\" + machineName + @"\root\CIMV2";
    		    string query = string.Format("Select FileSize from CIM_DataFile WHERE Name = '{0}'", DSADatabaseFile);
    		    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    		    ManagementObjectCollection collection = searcher.Get();
    		    foreach (ManagementObject mobj in searcher.Get())
    		    {
    				Console.WriteLine("File Size : " + mobj["FileSize"]);
    		    }
    		    return 0;
    		}
    
    		public static void Main(string[] args)
    		{
    			var p = new Program();
    
    			// These work
    			p.getDatabaseFileSize("C:/boot.ini", ".");
    			p.getDatabaseFileSize(@"C:\\boot.ini", ".");
    			p.getDatabaseFileSize("C:\\\\boot.ini", ".");
    
    			// These fail
    			try {
    				p.getDatabaseFileSize("C:\\boot.ini", ".");
    			} catch (ManagementException ex) { 
    				Console.WriteLine("Failed: {0}", ex.ErrorCode);
    			}
    			try {
    				p.getDatabaseFileSize(@"C:\boot.ini", ".");
    			} catch (ManagementException ex) { 
    				Console.WriteLine("Failed: {0}", ex.ErrorCode);
    			}
    		}
    	}
    }
