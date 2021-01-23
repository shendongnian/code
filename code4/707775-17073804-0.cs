    DataTable dt = null;
    for (int i = 0; i < UserClassDict[UserName].ControlNumber.Count; i++)
    {
        string query = "SELECT * FROM [FNF Taxes] WHERE ControlNumber =" + UserClassDict[UserName].ControlNumber[i] + ";";
        adapter.SelectCommand = new OleDbCommand(query, conn);
        DataSet dataset = new DataSet();
        adapter.Fill(dataset);
    
        if (dataset.Tables[0].Rows.Count > 0)
        {
            if (dt == null)
                dt = dataset.Tables[0].Clone();
            dt.Merge(dataset.Tables[0]);
        }
    }
    return dt;
