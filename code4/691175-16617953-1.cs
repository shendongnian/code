     public class ExcelParser : IDisposable
     {
        string filename;
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
        
        public ExcelParser(HttpPostedFile file)
        {
           filename = String.Format("{0}{1}.xlsx", System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());
           file.SaveAs(filename);
        }
    
        public MyData Process()
        {
           OleDbConnection conn = new OleDbConnection(String.Format(connStr, filename));
           conn.Open();
    
           OleDbCommand cmd = new OleDbCommand("Select * From [Sheet1$]", conn);
           OleDbDataReader reader = cmd.ExecuteReader();
    
           while (reader.Read())
           {
              // Build Data to return
           }
    
           reader.Close();
           conn.Close();
           return data; // Return data you built
        }
    
        public void Dispose()
        {
           File.Delete(filename);
        }
     }
