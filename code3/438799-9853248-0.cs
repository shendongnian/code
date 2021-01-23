    enum CurrencyIsoCode
    {
        USD,
        KWD,
        JPY,
        XCD,
        TVD
    }
    class Currency
    {
        public Currency() : this(false) { }
        public Currency(bool inner) { }
        public static IEnumerable<Currency> GetCachedCurrencies()
        {
            return new[] { 
                 new Currency () { currencyCode = CurrencyIsoCode.USD },
                 new Currency () { currencyCode = CurrencyIsoCode.JPY },
                 new Currency () { currencyCode = CurrencyIsoCode.XCD }
               };
        }
        
        public  CurrencyIsoCode  currencyCode { set; get; }
        
        public string AlphabeticCode
        {
            get { return currencyCode.ToString(); } 
        }
        public static Currency Get(CurrencyIsoCode isOCode)
        {
            return new Currency() { currencyCode = isOCode };
        }
    }
    class Program
    {
        private static IEnumerable<Currency> _commonCurrencies = null;
        static void Main(string[] args)
        {
            var currencies = GetCommonCurrencies();
            foreach (var curr in currencies)
                Console.WriteLine(curr.AlphabeticCode);
            Console.Read();
        }
        
        
        public static IEnumerable<Currency> GetCommonCurrencies() 
        {
            return _commonCurrencies ??
               ( _commonCurrencies
                = Currency.GetCachedCurrencies()
                      .Concat(new[] {Currency.Get(CurrencyIsoCode.KWD)})
                      .Where(x => !x.AlphabeticCode.StartsWith("X", StringComparison.InvariantCultureIgnoreCase))
                      .OrderBy(x => x.AlphabeticCode));
        }       
    }  
