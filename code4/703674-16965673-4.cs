    class Country
    {
        public int Id { get; set; }
        public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; }
    }
    class Currency
    {
        public int Id { get; set; }
    }
    class CountryCurrency
    {
        [Key, Column(Order=0)]
        public virtual int CountryId { get; set; }
        [Key, Column(Order=1)]
        public virtual int CurrencyId { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
    }
