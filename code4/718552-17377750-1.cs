    public class Die
    {
        private static Die _d2;
        public static Die D2
        {
            get
            {
                if(_d2 == null)
                    _d2 = new Die(DyeType.D2);
                return _d2;
            }
        }
        private static Die _d3 ...
    }
