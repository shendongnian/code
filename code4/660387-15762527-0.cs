    protected DataTable readDr()
    {
            con.Open();
            string str = "select CCNo,TotalAmt,NoOfRect,Energy,New1,Theft,Misc from ChallanTable;";
            cmd = new SqlCommand(str, con);
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            dt.Load(rdr);
            rdr.Close();
            con.Close();
    }
