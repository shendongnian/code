    for(int i=0; i<ConditonQueue.Count; i++)
    {
         DV.RowFilter = ConditonQueue.ElementAt(i);
         DV = DV.ToTable().AsDataView();
    }
