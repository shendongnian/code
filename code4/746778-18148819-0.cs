    @{
    var products = Model.Collection.Products.DistinctBy(p => p.id);
    decimal[] minimalPrices = new decimal[products.Length];
    @for(int i = 0; i < products.Length; i++))
    {
      decimal min = Decimal.MaxValue;
      @foreach (var market in Model.Markets)
      {
        //..compute price and compare to min        
      }
      minimalPrices[i] = min;
    }
    }
