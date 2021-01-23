    public Tuple<decimal, decimal> GetPrices(int ID)
    {
        Item item = databaseCallToGetPrice(ID).First();
        return Tuple.Create(item.ExamplePrice, item.PremiumExamplePrice);
    }
