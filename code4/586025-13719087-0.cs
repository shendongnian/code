    public class Coffee
    {
        private bool _cream;
        private int _ounces;
        // I really don't like this kind of instantiation,
        // but I kept it there and made static to make it work.
        public static Coffee Make { get new Coffee(); }
        public Coffee WithCream()
        {
            return new Coffee
            {
                _cream = true,
                _ounces = this._ounces
            }
        }
        public Coffee WithOuncesToServe(int ounces)
        {
            return new Coffee
            {
                _cream = this._cream,
                _ounces = ounces
            };
        }
