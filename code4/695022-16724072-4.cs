    static Tuple<TRow,TCol>[,] CreateMatrix<TRow,TCol>( TRow[] rows , TCol[] cols )
    {
      Tuple<TRow,TCol>[,] matrix = new Tuple<TRow,TCol>[rows.Length,cols.Length];
      
      for ( int r = 0 ; r < rows.Length ; ++r )
      {
        for ( int c = 0 ; c < cols.Length ; ++c )
        {
          Tuple<TRow,TCol> cell = new Tuple<TRow,TCol>( rows[r] , cols[c] ) ;
          matrix[r,c] = cell ;
        }
      }
      
      return matrix ;
    }
