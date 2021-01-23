    private DictionaryWrapper<Fuel, Price> pricesWrapper = 
        new DictionaryWrapper<Fuel, Price> (
               new Dictionary<Fuel, Price> (), price => price.Fuel) ;
    [XmlElement("price")]
    public ICollection<Price> Prices
    {
        get { return pricesWrapper ; } // NB: no setter is necessary
    }
