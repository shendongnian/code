    public class SampleMouseMove
    {
        delegate void BeginMoveMouseDelegate(int x, int y, int rx, int ry);
        Random random = new Random();
        int mouseSpeed = 15;
        bool killMove = false;
        bool running = false;
        ManualResetEvent mre = new ManualResetEvent(false);
        
        public SampleMouseMove()
        { }
        
        public void BeginMoveMouse(int x, int y, int rx, int ry)
        {
            if (running)
                throw new Exception("Mouse is already being moved.");
            BeginMoveMouseDelegate del = new BeginMoveMouseDelegate(MoveMouse);
            del.BeginInvoke(x, y, rx, ry, new AsyncCallback(BeginMoveMouseCallback), del);
            running = true;
        }
    
        public void StopMoveMouse()
        {
            killMove = true;
            mre.Set();
        }
    
        void BeginMoveMouseCallback(IAsyncResult state)
        {  
            BeginMoveMouseDelegate del = (BeginMoveMouseDelegate)state.AsyncState;
            del.EndInvoke(state);
            mre.Reset();
            killMove = false;
            running = false;
        }
    
        public void MoveMouse(int x, int y, int rx, int ry)
        {
            Point c = new Point();
            GetCursorPos(out c);
    
            x += random.Next(rx);
            y += random.Next(ry);
    
            double randomSpeed = Math.Max((random.Next(mouseSpeed) / 2.0 + mouseSpeed) / 10.0, 0.1);
    
            WindMouse(c.X, c.Y, x, y, 9.0, 3.0, 10.0 / randomSpeed,
                15.0 / randomSpeed, 10.0 * randomSpeed, 10.0 * randomSpeed);
        }
    
        void WindMouse(double xs, double ys, double xe, double ye,
            double gravity, double wind, double minWait, double maxWait,
            double maxStep, double targetArea)
        {
    
            double dist, windX = 0, windY = 0, veloX = 0, veloY = 0, randomDist, veloMag, step;
            int oldX, oldY, newX = (int)Math.Round(xs), newY = (int)Math.Round(ys);
    
            double waitDiff = maxWait - minWait;
            double sqrt2 = Math.Sqrt(2.0);
            double sqrt3 = Math.Sqrt(3.0);
            double sqrt5 = Math.Sqrt(5.0);
    
            dist = Hypot(xe - xs, ye - ys);
    
            while (dist > 1.0 && !killMove)
            {
    
                wind = Math.Min(wind, dist);
    
                if (dist >= targetArea)
                {
                    int w = random.Next((int)Math.Round(wind) * 2 + 1);
                    windX = windX / sqrt3 + (w - wind) / sqrt5;
                    windY = windY / sqrt3 + (w - wind) / sqrt5;
                }
                else
                {
                    windX = windX / sqrt2;
                    windY = windY / sqrt2;
                    if (maxStep < 3)
                        maxStep = random.Next(3) + 3.0;
                    else
                        maxStep = maxStep / sqrt5;
                }
    
                veloX += windX;
                veloY += windY;
                veloX = veloX + gravity * (xe - xs) / dist;
                veloY = veloY + gravity * (ye - ys) / dist;
    
                if (Hypot(veloX, veloY) > maxStep)
                {
                    randomDist = maxStep / 2.0 + random.Next((int)Math.Round(maxStep) / 2);
                    veloMag = Hypot(veloX, veloY);
                    veloX = (veloX / veloMag) * randomDist;
                    veloY = (veloY / veloMag) * randomDist;
                }
    
                oldX = (int)Math.Round(xs);
                oldY = (int)Math.Round(ys);
                xs += veloX;
                ys += veloY;
                dist = Hypot(xe - xs, ye - ys);
                newX = (int)Math.Round(xs);
                newY = (int)Math.Round(ys);
    
                if (oldX != newX || oldY != newY)
                    SetCursorPos(newX, newY);
    
                step = Hypot(xs - oldX, ys - oldY);
                int wait = (int)Math.Round(waitDiff * (step / maxStep) + minWait);
    
                mre.WaitOne(wait);  // <-- this works like Thread.Sleep(), but we can cancel the "wait" by calling mre.Set();
            }
    
            int endX = (int)Math.Round(xe);
            int endY = (int)Math.Round(ye);
            if (endX != newX || endY != newY)
                SetCursorPos(endX, endY);
        }
    
        double Hypot(double dx, double dy)
        {
            return Math.Sqrt(dx * dx + dy * dy);
        }
    
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
    
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point p);
    }
