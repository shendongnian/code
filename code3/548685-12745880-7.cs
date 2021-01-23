    public static void ToSimpleQuote(this Quote quote){
        return new SimpleQuote(){ 
            Id = quote.Id,
            Amount = quote.Amount,
            Product = quote.Product.ToSimpleProduct()
        };
    }
    
    public static void ToSimpleProduct(this Product product){
        return new SimpleProduct(){
            Id = product.Id,
            Name = product.Name,
            QuoteId = product.Quote.QuoteID
        };
    }
