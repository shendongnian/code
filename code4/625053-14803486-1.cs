    var qry = data.Adresses.Where(sr => sr.Customer_GUID == CustomerGuid)
                           .Select(sr => new {
                                                sr.Address_GUID,
                                                ....
                                                
                                                sr.AddressType.AddressType_Desc, 
                                                sr.Country.Country_Desc
                                             });
