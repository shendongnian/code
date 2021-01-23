    foreach(DataRow tr in transM.Rows)
    {
        string idValue = tr["ID"].ToString();
        DataRow[] foundRows = tableDGV1.Select("ID = " + idValue);
        if(foundRows.Length == 1)
        {
           // Here you have the internal row to join with the external one
            string joinedString = tr["Tr"].ToString() + "," + foundRows[0]["Tr"].ToString();
            string[] trSplit = joinedString.Split(new char[] {','}, 
                               StringSplitOptions.RemoveEmptyEntries);
            List<string> listTr = trSplit.Distinct().ToList();                        
            .........
        }
    }
