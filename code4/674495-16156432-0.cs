    for (int i = 0; i < assigneeIDs.Count; i++)
    {
        SQLiteParameter[] param = new SQLiteParameter[3];
        
        SQLiteParameter p1 = new SQLiteParameter("request_id", DbType.Int32);
        SQLiteParameter p2 = new SQLiteParameter("sequence", DbType.Double);
        SQLiteParameter p3 = new SQLiteParameter("date_assigned", DbType.String);
    
        p1.Value = requestID;
        p2.Value = Convert.ToDouble(last_seq + "." + (i + 1));
        p3.Value = DateTime.Now.ToString(ThisAddIn.FullDate);
    
        param[0] = p1;
        param[1] = p2;
        param[2] = p3;
    
        paramList.Add(param);
    }
