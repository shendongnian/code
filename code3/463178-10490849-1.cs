        public static void Move(int xDelta, int yDelta, int timeInMilliseconds)
        {
            if (xDelta == 0 && yDelta == 0) return;
            if (timeInMilliseconds == 0)
            {
                Move(xDelta, yDelta);
                return;
            }
    
            var xRate = xDelta == 0 ? -1 : (double)timeInMilliseconds / xDelta;
            var yRate = yDelta == 0 ? -1 : (double)timeInMilliseconds / yDelta;
    
            var xThread = new Thread(() =>
                                         {
                                             if (xDelta == 0) return;
    
                                             var sw = Stopwatch.StartNew();
                                             var c = 1;
    
                                             for (var i = 0; i < xDelta; i++)
                                             {
                                                 while (sw.ElapsedMilliseconds / xRate < c)
                                                 {
                                                 }
    
                                                 c++;
    
                                                 Move(1, 0);
                                             }
                                         });
         
            var yThread = new Thread(() =>
                                         {
                                             if (yDelta == 0) return;
    
                                             var sw = Stopwatch.StartNew();
                                             var c = 1;
    
                                             for (var i = 0; i < yDelta; i++)
                                             {
                                                 while (sw.ElapsedMilliseconds / yRate < c)
                                                 {
                                                 }
    
                                                 c++;
    
                                                 Move(0, 1);
                                             }
                                         });
    
            xThread.Start();
            yThread.Start();
    
            xThread.Join();
            yThread.Join();
        }
