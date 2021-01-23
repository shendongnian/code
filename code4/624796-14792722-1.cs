    private object Lock = new object();
      lock (Lock) {
           
          using (var g = Graphics.FromImage(videoBox.Image) {  
            
            Pen p = new Pen(Color.Black, 2);
    
            cellSize = 100;
            cellsNumber = 4;
    
            for (int y = 0; y <= cellsNumber; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, cellsNumber * cellSize, y * cellSize);
            }
    
            for (int x = 0; x <= cellsNumber; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, cellsNumber * cellSize);
            }
            
            g.Dispose();
    
         }        
      }
