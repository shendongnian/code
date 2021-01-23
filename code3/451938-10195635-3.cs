    IQueryble<myTicket> query = from ts in context.Tickets
                              join ps in context.Products 
                                   on t.ProductToken equals p.Token into p
                              select new myTicket
                              {
                                  Id = t.Id,  
                                  SerialNumber = t.SerialNumber,
                                  ProductToken = t.ProductToken,
                                  Product = p.FirstOrDefault()
                              };
