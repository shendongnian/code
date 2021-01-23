    string strsql = "SELECT * FROM ServerATable";
    using (ONcon = new SqlConnection(conString))
    using (ONda = new SqlDataAdapter(strsql, ONcon))
    {
        ONcon.Open();
        ONds = new DataSet();
        ONda.Fill(ONds, "serverA_table");
    }
    strsql = "SELECT * FROM ServerBTable";
    using (OFFcon = new SqlConnection(conString))
    using (OFFda = new SqlDataAdapter(strsql, OFFcon))
    {
        OFFcon.Open();
        OFFds = new DataSet();
        OFFda.Fill(OFFds, "serverB_table");
        DataRow[] newRow = ONds.Tables["serverA_table"].Select();
        foreach (DataRow temp in newRow)
        {
            temp.SetAdded();
            OFFds.Tables["serverB_table"].ImportRow(temp);
        }
        SqlCommandBuilder cb = new SqlCommandBuilder(OFFda);
        OFFda.InsertCommand = cb.GetInsertCommand();
        OFFda.UpdateCommand = cb.GetUpdateCommand();
        OFFda.DeleteCommand = cb.GetDeleteCommand();
        OFFda.Update(OFFds.Tables["serverB_table"]);
    }
