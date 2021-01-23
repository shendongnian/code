    DataColumn[] parentColumns=null;
    DataColumn[] childColumns=null;
    
    parentColumns = new DataColumn[] { yourDataset.Tables[0].Columns["Date"], yourDataset.Tables[0].Columns["Comment"]};
    
    childColumns = new DataColumn[] { yourDataset.Tables[1].Columns["Date"], yourDataset.Tables[1].Columns["Comment"]};
    
    yourDataset.Relations.Add(new DataRelation("Date-Comment-Relation", parentColumns, childColumns));
