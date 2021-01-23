        public static void Move(int xDelta, int yDelta, int timeInMilliseconds)
        {
            // No need to move the mouse at all.
            if (xDelta == 0 && yDelta == 0) return;
            // No need to move smoothly.
            if (timeInMilliseconds <= 0)
            {
                Move(xDelta, yDelta);
                return;
            }
            // Set direction factors and then make the delta's positive
            int xFactor = 1;
            int yFactor = 1;
            if (xDelta < 0)
            {
                xDelta *= (xFactor = -1);
            }
            if (yDelta < 0)
            {
                yDelta *= (yFactor = -1);
            }
            // Calculate the rates of a single x or y movement, in milliseconds
            // And avoid dividing by zero
            var xRate = xDelta == 0 ? -1 : (double)timeInMilliseconds / xDelta;
            var yRate = yDelta == 0 ? -1 : (double)timeInMilliseconds / yDelta;
            // Make a thread that will move the mouse in the x direction
            var xThread = new Thread(() =>
                                         {
                                             // No need to move in the x direction
                                             if (xDelta == 0) return;
    
                                             var sw = Stopwatch.StartNew();
                                             var c = 1;
    
                                             for (var i = 0; i < xDelta; i++)
                                             {
                                                 // Wait for another "rate" amount of time to pass
                                                 while (sw.ElapsedMilliseconds / xRate < c)
                                                 {
                                                 }
    
                                                 c++;
                                                 // Move by a single pixel (x)
                                                 Move(xFactor, 0);
                                             }
                                         });
            // Make a thread that will move the mouse in the y direction
            var yThread = new Thread(() =>
                                         {
                                             // No need to move in the y direction
                                             if (yDelta == 0) return;
    
                                             var sw = Stopwatch.StartNew();
                                             var c = 1;
    
                                             for (var i = 0; i < yDelta; i++)
                                             {
                                                 // Wait for another "rate" amount of time to pass
                                                 while (sw.ElapsedMilliseconds / yRate < c)
                                                 {
                                                 }
    
                                                 c++;
                                                 // Move by a single pixel (y)
                                                 Move(0, yFactor);
                                             }
                                         });
    
            // Activate the movers threads
            xThread.Start();
            yThread.Start();
    
            // Wait for both to end (remove this if you want it async)
            xThread.Join();
            yThread.Join();
        }
