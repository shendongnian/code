    int pageStart = 0;
    
    List<DataRowView> pageRows = new List<DataRowView>();
    
    for (int i = pageStart; i < dtAllData.DefaultView.Count; i++ )
    {
       if(pageStart + 25 > i || i == dtAllData.DefaultView.Count - 1) { break; //Exit if more than the number of pages or at the end of the rows }
       pageRows.Add(dtAllData.DefaultView[i]);
    }
