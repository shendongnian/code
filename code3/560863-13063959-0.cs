    DataView DV = DataTable.AsDataView();
    
    string[] filter = new string[ConditonQueue.Count];
    for(int i=0; i<ConditonQueue.Count; i++)
    {
         filter[i] =  ConditonQueue.ElementAt(i).ToString();
    }
    
    DV.RowFilter = String.Join(" AND ", filter); // filter1 AND filter2 AND ... AND filterN
