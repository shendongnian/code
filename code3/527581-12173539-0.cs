    da2.Fill(ds, "DNAiusTwitter_Table");
    int counts = ds.Tables[0].Rows.Count;
    StringBuilder appendString = new StringBuilder();
    for (int i = 0; i < counts; i++)
    {
        appendString.AppendFormat("{0},", ds.Tables[0].Rows[i][3].ToString());
    }
