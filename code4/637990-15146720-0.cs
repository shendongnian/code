        private void characterGrid_SelectionChanged( object sender, EventArgs e )
        {
            if ( SelectionChanging == true )
            {
                return;
            }
            SelectionChanging = true;
            var la = characterGrid.SelectedCells;
            if ( la.Count > 1 )
            {
                var sorted = new List<DataGridViewCell>();
                System.Collections.IEnumerator enumerator = la.GetEnumerator();
                while ( enumerator.MoveNext() )
                {
                    sorted.Add( (DataGridViewCell)enumerator.Current );
                }
                sorted.Sort( delegate( DataGridViewCell t1, DataGridViewCell t2 )
                {
                    if ( t1.RowIndex != t2.RowIndex )
                    {
                        return t1.RowIndex.CompareTo( t2.RowIndex );
                    }
                    else
                    {
                        return t1.ColumnIndex.CompareTo( t2.ColumnIndex );
                    }
                });
                var rowFirst = ( (DataGridViewCell)sorted[ 0 ] ).RowIndex;
                var columnFirst = ( (DataGridViewCell)sorted[ 0 ] ).ColumnIndex;
                var rowLast = ( (DataGridViewCell)sorted[ sorted.Count - 1 ] ).RowIndex;
                var columnLast = ( (DataGridViewCell)sorted[ sorted.Count - 1 ] ).ColumnIndex;
                if ( rowLast > rowFirst )
                {
                    // select first row
                    for ( int column = columnFirst; column < characterGrid.ColumnCount; column++ )
                    {
                        characterGrid[ column, rowFirst ].Selected = true;
                    }
                    // in between
                    for ( int row = rowFirst + 1; row < rowLast; row++ )
                    {
                        for ( int column = 0; column < characterGrid.ColumnCount; column++ )
                        {
                            characterGrid[ column, row ].Selected = true;
                        }
                    }
                    // last row
                    for ( int column = 0; column <= columnLast; column++ )
                    {
                        characterGrid[ column, rowLast ].Selected = true;
                    }
                }
            }
            SelectionChanging = false;
        }
