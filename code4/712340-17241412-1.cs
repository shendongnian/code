        void SomeMethod() {
          // :  
          HexgridPath   = SetGraphicsPath();
          // :
        }
              
        GraphicsPath SetGraphicsPath() {
          GraphicsPath path     = null;
          GraphicsPath tempPath = null;
          try {
            tempPath  = new GraphicsPath();
            tempPath.AddLines(new Point[] {
              new Point(GridSize.Width*1/3,                0), 
              new Point(GridSize.Width*3/3,                0),
              new Point(GridSize.Width*4/3,GridSize.Height/2),
              new Point(GridSize.Width*3/3,GridSize.Height  ),
              new Point(GridSize.Width*1/3,GridSize.Height  ),
              new Point(                 0,GridSize.Height/2),
              new Point(GridSize.Width*1/3,                0)
            } );
            path     = tempPath;
            tempPath = null;
          } finally { if(tempPath!=null) tempPath.Dispose(); }
          return path;
        }
