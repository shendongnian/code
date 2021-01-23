        public int PercentToPoint(int percent)
        {
            return (int)Math.Round(Convert.ToDouble(percent * 12 / 100));
        }
        public int PercentToPixel(int percent)
        {
            return (int)Math.Round(Convert.ToDouble(percent * 16 / 100));
        }
