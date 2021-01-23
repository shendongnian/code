    public Prices GetPrices(int ID)
    {
        Item item = databaseCallToGetPrice(ID).First();
        return new Prices(item.PremiumExamplePrice, item.ExamplePrice);
    }
