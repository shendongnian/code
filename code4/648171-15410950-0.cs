    int numberOfRecords = 0;
    using(var ctx = new DomainContext())
    {
      foreach (var item in deals)
              {
                  DealsOfReutersAddition newDealAddition =
                              new DealsOfReutersAddition
                              {
                                  DealsOfReutersId = item.DealsOfReutersId,
                                  DealDate = DateTime.Parse(item.DateConfirmed ?? "01 01 01", new CultureInfo("en-US")),
                              };
    
                  ctx.DealsOfReutersAdditions.Add(newDealAddition);
    
                  numberOfRecords++;
                  if(numberOfRecords % 500 == 0) //Saves after every 500 rows.
                  {
                    ctx.SaveChanges();
                  }
               }
    }
