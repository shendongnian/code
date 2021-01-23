    var rawGroups = db.Items.Where(item.Expiry >= DateTime.Now && ord.Expiry <= maxDate)
                            .ToLookup(item => new
                               {
                                item.Expiry.Value.Year,
                                item.Expiry.Value.Month
                               }, item => 1)
                            .ApplyResultSelector((k,g) => new ExpiriesOwnedModel()
                              {
                                Month = k.Month,
                                Quantity = g.Count()
                              }));
    var result = Enumerable.Range(DateTime.Now.Month,6)
                           .Select(i => i > 12 ? i - 12 , i)
                           .Select(i => rawGroups.Contains(i) ?
                                        rawGroups[i] :
                                        new ExpiriesOwnedModel() 
                                        { Month = i , Quantity = 0 });
    
