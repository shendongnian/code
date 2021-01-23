    using System.Linq; 
    using System.Text; 
    using System.Data; 
    using System.Data.OleDb;
    
    namespace DAL 
    {
        public class OLEDBhelper
        {
            private static string ConnectionString = 
                @"Provider=Microsoft.Jet.OLEDB.4.0;" + 
                @"Data source= " + System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory) + "\AccessFile.mdb";
        }
    }
