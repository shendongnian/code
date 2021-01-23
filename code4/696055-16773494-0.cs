    class Turns
    {
        static DateTime prevTimeInstance = DateTime.Now;
        static float RPM = 0;
        public float Counts(int getTurn)
        {
            TimeSpan currentTimeSpan = TimeSpan.Zero;
            if (getTurn.Equals(1))
            {
                currentTimeSpan = DateTime.Now.Subtract(prevTimeInstance);
                prevTimeInstance = DateTime.Now;
                if (currentTimeSpan.TotalSeconds != 0)
                    RPM = 60.0f / (float)currentTimeSpan.TotalSeconds;
            }
            return RPM;
        }
    }
