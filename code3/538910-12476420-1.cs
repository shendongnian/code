    public int Autogenerate()
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Directory.GetCurrentDirectory() + "/CleaningTroopers.mdb");
        con.Open();
        string str4 = "select iif(isnull(max(uom_code)),1000,max(uom_code)+1) from uom_master ";
        cmd = new OleDbCommand(str4, con);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return Convert.ToInt32(dt.Rows[0][0]);
        con.Close();
    }
