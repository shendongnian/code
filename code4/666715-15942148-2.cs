    static void Main(string[] args)
    {
        var constrBuilder = new FbConnectionStringBuilder();
        constrBuilder.DataSource = "localhost";
        constrBuilder.Database = @"D:\data\db\testdatabase.fdb";
        constrBuilder.UserID = "sysdba";
        constrBuilder.Password = "masterkey";
    
        string constr = constrBuilder.ToString();
    
        using (var con = new FbConnection(constr))
        {
            con.Open();
            using (var trans = con.BeginTransaction())
            {
                var cmd = new FbCommand();
                cmd.CommandText = "INSERT INTO COUNTRY1 SELECT '2', 'two ' FROM RDB$DATABASE UNION ALL SELECT '4', 'four' FROM RDB$DATABASE UNION ALL SELECT '5', 'five' FROM RDB$DATABASE";
                cmd.Connection = con;
                cmd.Transaction = trans;
    
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
        }
    }
