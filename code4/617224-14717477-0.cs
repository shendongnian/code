    int[,] time = new int[5, 2] { { 0, 4 }, { 1, 5 }, { 5, 10 }, { 3, 4 }, { 0, 2 } };
            
    var sorted = from x in Enumerable.Range(0, time.GetLength(0))
                         select new Point()
                         {
                             X = time[x,0],
                             Y = time[x,1]
                         } into point
                         orderby point.X ascending , point.Y ascending 
                         select point;
