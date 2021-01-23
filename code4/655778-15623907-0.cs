    class MoneyClass
    {
        private decimal MoneyValue;
        public decimal getmoney()
        { return MoneyValue; }
        public setmoney(decimal Value)
        { MoneyValue = Value; }
    }
    class Bank
    {
        public MoneyClass Money;
    }
