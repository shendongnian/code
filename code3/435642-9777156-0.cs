    var rows = table.Elements<TableRow>();
    var firstRowCells = rows.ElementAt(0).Elements<TableCell>();
    var cellNumbersToDelete = new List<int>();
    for( int i=0; i<firstRowCells.Count(); i++ )
      if( GetCellText( firstRowCells.ElementAt( i ) ) == "Hello" )
        cellNumbersToDelete.Add( i );
    foreach( var cellNumberToDelete in cellNumbersToDelete ) {
      foreach( var row in rows ) {
        cellToDelete = row.ElementAt( cellNumberToDelete );
        row.RemoveChild( cellToDelete );
      }
    }
