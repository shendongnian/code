    using (OleDbConnection oconn = new OleDbConnection()) {
        oconn.ConnectionString = "Provider=vfpoledb.1;Data Source=" + pelna_sciezka + ";Collating Sequence=machine"; 
        oconn.Open(); 
        using (OleDbCommand ocmd = oconn.CreateCommand()) {
            string na = TBNazwaKonta.Text.Replace("\n",""); 
            na = na.Replace("\r","") ; 
            string ks2 = ks.Replace("\n",""); 
            ks2 = ks2.Replace("\r", ""); 
            using (OleDbCommand dbCmdNull = oconn.CreateCommand()) {
                dbCmdNull.CommandText = "SET NULL OFF"; 
                dbCmdNull.ExecuteNonQuery();
            } // closes dbCmdNull
            string zapytanie = @"insert into " + @pelna_sciezka + @" (rk, Na,Ks) values (0,'" + na + "','" + ks2 +"')"; 
            ocmd.CommandText = zapytanie; 
            ocmd.ExecuteNonQuery(); 
        }  // closes ocmd
    } // closes connection
