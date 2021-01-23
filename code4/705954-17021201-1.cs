    public struct Vector2<T> where T : IConvertible
    {
        private readonly double x;
        private readonly double y;
        public Vector2(T x, T y)
        {
            this.x = x.ToDouble(CultureInfo.CurrentCulture);
            this.y = y.ToDouble(CultureInfo.CurrentCulture);
        }
        public T X
        {
            get
            {
                return ConvertBack(this.x);
            }
        }
        public T Y
        {
            get
            {
                return ConvertBack(this.y);
            }
        }
        private static T ConvertBack(double d)
        {
            return (t)Convert.ChangeType(d, typeof(T), CultureInfo.CurrentCulture); 
        }
    }
