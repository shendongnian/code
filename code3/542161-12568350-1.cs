    using System; 
    using Oracle.DataAccess.Client; 
    class Example 
    { 
    OracleConnection con; 
    void Connect() 
    { 
    con = new OracleConnection(); 
    con.ConnectionString = "User Id=<username>;Password=<password>;Data Source=<datasource>"; 
    con.Open(); 
    Console.WriteLine("Connected to Oracle" + con.ServerVersion); 
    } 
    void Close() 
    {
    con.Close(); 
    con.Dispose(); 
    } 
    static void Main() 
    { 
    Example example = new Example(); 
    example.Connect(); 
    example.Close(); 
    } 
    }
