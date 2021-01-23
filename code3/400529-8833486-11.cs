    var result = lstServerBindings.GroupBy(x => x.DomainName.StartsWith("www.") ? 
                                                x.DomainName : "www." + x.DomainName)
                                  .Select(x =>
                                          {
                                              var item =
                                                  x.FirstOrDefault(y => 
                                                    y.DomainName.StartsWith("www."));
                                              if (item == null)
                                                  item = x.First();
                                              return new ServerBindings
                                                  {
                                                      IPAddress = item.IPAddress,
                                                      PortNumber = item.PortNumber,
                                                      DomainName = item.DomainName
                                                  };
                                          });
