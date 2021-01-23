    private void ScrollBlock(Arxl[,] cartesianGrid, int arxlAmount) {
             int x = 0;
             int y = 0;
             List<Point> updateList = new List<Point>();
             for( x = 0; x < arxlAmount; x++ ) {
                for( y = 0; y < arxlAmount; y++ ) {
                   if( _cartesianGrid[x, y].Active == true ) {
                      if( x >= 0 ) {
                         if( x == (arxlAmount - 1) ) {
                            _cartesianGrid[x, y].Active = false;
                            //_cartesianGrid[1, y].Active = true;
                            updateList.Add(new Point(1, y));
                         } else if( x < (arxlAmount - 1) ) {
                            _cartesianGrid[x, y].Active = false;
                            //_cartesianGrid[x + 1, y].Active = true;
                            updateList.Add(new Point(x + 1, y));
                         }
                      }
                   }
                  
                }
             }
             foreach( var pt in updateList ) {
                _cartesianGrid[pt.X, pt.Y].Active = true;
             }
          }
