    public class Range
    {
        public double RangeValue { get; set; }
        public Thickness RangeMargin
        {
            get
            {
                if (RangeValue.ToString().Length == 1)
                {
                    return new Thickness(-1, 0, -1, 0);
                }
                else if (RangeValue.ToString().Length == 2)
                {
                    return new Thickness(-5, 0, -5, 0);
                }
                else if (RangeValue.ToString().Length == 3)
                {
                    return new Thickness(-7, 0, -7, 0);
                }
                else if (RangeValue.ToString().Length == 4)
                {
                    return new Thickness(-9, 0, -9, 0);
                }
                else
                    return new Thickness(-1, 0, -1, 0);
            }
        }
    }
