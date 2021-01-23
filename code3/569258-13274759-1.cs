    var rawGroups = db.Items.Where(item.Expiry >= DateTime.Now && ord.Expiry <= maxDate)
                            .GroupBy(item => new
                               {
                                item.Expiry.Value.Year,
                                item.Expiry.Value.Month
                               }, g => new ExpiriesOwnedModel()
                              {
                                Month = g.Key.Month,
                                Quantity = g.Count()
                              }).ToDictionary(model => model.Month);
    var result = Enumerable.Range(DateTime.Now.Month,6)
                           .Select(i => i > 12 ? i - 12 , i)
                           .Select(i => rawGroups.Contains(i) ?
                                        rawGroups[i] :
                                        new ExpiriesOwnedModel() 
                                        { Month = i , Quantity = 0 });
    
