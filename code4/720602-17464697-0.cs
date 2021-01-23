    //Aggregates the series - For our app we're using from the third to the last column generated from the datatable used for our chart.
    Series mySerie = new Series();
    mySerie.Name = myAux.Columns[1].ColumnName;
    mySerie.XValueMember = myAux.Columns[0].ColumnName;
    
    for (i = 2; i < myAux.Columns.Count; i++)
    {
        mySerie.YValueMembers = myAux.Columns[i].ColumnName;
    }
    
    this.chartReport.Series.Add(mySerie);
