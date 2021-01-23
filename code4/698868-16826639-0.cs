    public interface ICurrency
    {
        int CurrencyValue { get; set; }
        void ExchangeRate(double percent);
    }
