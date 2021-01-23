    var subQuery = 
          QueryOver.Of<LineItem>(() => lineItem)
                .JoinAlias(() => lineItem.Products, () => product)
                .Where(() => product.Name == "foo")
                .Select(Projections.Distinct(
                          Projections.Property(()=> lineItem.Order.Id)));;
    
    var theQueryYouNeed =  
                   QueryOver.Of<Orders>(() => order)
                  .WithSubquery.WherePropertyIn(() => order.Id).In(subQuery); 
