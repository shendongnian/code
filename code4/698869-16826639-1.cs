    public class UsDollar : ICurrency
    {
        public int CurrencyValue { get; set; }
     
        public void ExchangeRate(double percent)
        {
            Console.WriteLine("Your Exchange Rate for Us Dollar is {0}", CurrencyValue * percent);
        }
    }
     
    public class Euro : ICurrency
    {
        public int CurrencyValue { get; set; }
     
        public void ExchangeRate(double percent)
        {
            Console.WriteLine("Your Exchange Rate for Euro is {0}", CurrencyValue * percent);
        }
    }
     
    public class Rupee : ICurrency
    {
        public int CurrencyValue { get; set; }
     
        public void ExchangeRate(double percent)
        {
            Console.WriteLine("Your Exchange Rate for Rupee is {0}", CurrencyValue * percent);
        }
    }
