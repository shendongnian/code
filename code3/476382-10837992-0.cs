    static void Main(String[] args)
    {
       string strTestDirectory = @"Provider=VFPOLEDB.1; DataSource=D:\TEMP\";
    
       OleDbConnection VFPConn = new OleDbConnection(strTestDirectory);
       VFPConn.Open();
       if( VFPConn.State == System.Data.ConnectionState.Open )
          VFPConn.Close();
    }
