    var model = _serviceRepository.GetProducts()
                                  .Select(p => new ProductModel 
                                               { 
                                                   Id = p.Id, 
                                                   Name = p.Name, 
                                                   Credits = p.Credits, 
                                                   Months = p.Months, 
                                                   Price = p.Price
                                               })
                                  .ToList()
                                  .Select(x =>
                                          {
                                              x.PayPalButton = GenerateSubscriptionButton(x.Id);
                                              return x;
                                          }); 
