    DataTable newDT = new DataTable();
    newDT.Columns.Add("ServerName", typeof(string));
    newDT.Columns.Add("UserName", typeof(string));
    newDT.Columns.Add("LearningGroup", typeof(string));
    
    foreach (var item in tmpDT)
    {
    	newDT.ImportRow(item);
    }
