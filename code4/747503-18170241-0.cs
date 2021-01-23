    public sealed class Coins
    {
        private decimal _num;
        private Coins(decimal num)
        {
            _num = num;
        }
        public static readonly Coins OneCent = new Coins(0.01M);
        public static readonly Coins FiveCent = new Coins(0.05M);
        public static readonly Coins OneDollar = new Coins(1M);
        //add more properties like this
    }
