    greenParksDataSet.HistoryTable.Rows.Clear();
    HistoryTableBindingSource.EndEdit();
    
    historyTableTableAdapter.Update(greenParksDataSet);
    greenParksDataSet.AcceptChanges();
