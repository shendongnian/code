    public decimal[] GetPrice(int ID)
    {
      Item item = databaseCallToGetPrice(ID).first();
    
      return new [] {item.ExamplePrice, item.PremiumExamplePrice};
    }
