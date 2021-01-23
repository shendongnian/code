    private const int _minimumColumnWidth = 50;
    
    private void ListView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
    {
      if (ListView1.Columns[e.ColumnIndex].Width < _minimumColumnWidth)
                {
                    ListView1.Columns[e.ColumnIndex].Width = _minimumColumnWidth;
    
                }
    
     }
