    string fileName = @"C:\Users\janki.prashar\Desktop\k.xls";
        string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended     Properties=\"Excel 8.0;HDR=NO;IMEX=1\"";
        OleDbConnection con = new OleDbConnection(ConStr);
        con.Open();
        OleDbCommand ad = new OleDbCommand("select * from [SheetName$]", con);
        OleDbDataReader dr = ad.ExecuteReader();
        System.Data.DataTable dt = new System.Data.DataTable();
        dt.Load(dr);
        dataGridView1.DataSource = dt;
        con.Close();
