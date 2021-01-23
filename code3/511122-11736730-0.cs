    using System.Data;
    using System.Data.OleDb;
    
    //
    // Code ...
    //
    
    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\MyServer\Mydb.mdb");
    conn.open();
    //
    // Use connection ...
    //
