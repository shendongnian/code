    foreach (DataRow row in rows)
    {
        string line = "";
        for (int i = 0; i < row.ItemArray.Length; i++)
        {
             line += row[i] + ",";  
        }
        line = line.TrimEnd(',');
                   
    }
