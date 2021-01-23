        public IQueryable<Model.Order> GetOrders()
        {
            var orders = from o in _db.Orders
                                      .Include("User")
                                      .Include("OrderItems.Inventories.Product")
                                      .Include("Transactions")
                                      .Include("CustomerAddressBilling.Address")
                                      .Include("CustomerAddressBilling.Customer")
                                      .Include("CustomerAddressBilling.Contact")
                                      .Include("CustomerAddressShipping.Address")
                                      .Include("CustomerAddressShipping.Customer")
                                      .Include("CustomerAddressShipping.Contact")
                                      .Include("ShippingMethod")
                         let items = (o.OrderItems.Select(i => new Model.OrderItem
                             {
                                 OrderItemId = i.OrderItemId,
                                 OrderId = i.OrderId,
                                 DateAdded = i.CreateDate,
                                 LineItemPrice = i.Inventories.Sum(ii => ii.Product.Price),
                                 Product = i.Inventories.FirstOrDefault().Product,
                                 Quantity = i.Inventories.Count()
                             }))
                         let transactions = (o.Transactions.Select(t => new Model.Transaction
                             {
                                 Id = t.TransactionId,
                                 OrderId = t.OrderId,
                                 Amount = t.Amount,
                                 AuthorizationCode = t.AuthorizationCode,
                                 DateExecuted = t.TransactionDate,
                                 Notes = t.Notes,
                                 Processor = (Model.TransactionProcessor)t.ProcessorId
                             }))
                         let cab = new Model.CustomerAddress
                             {
                                 Id = o.CustomerAddressBilling.CustAddId,
                                 UserName = o.User.UserName,
                                 FirstName = o.CustomerAddressBilling.Customer.FirstName,
                                 LastName = o.CustomerAddressBilling.Customer.LastName,
                                 MiddleInitial = o.CustomerAddressBilling.Customer.MiddleName,
                                 Salutation = o.CustomerAddressBilling.Customer.Salutation,
                                 Suffix = o.CustomerAddressBilling.Customer.Suffix,
                                 Street1 = o.CustomerAddressBilling.Address.Line1,
                                 Street2 = o.CustomerAddressBilling.Address.Line2,
                                 Street3 = o.CustomerAddressBilling.Address.Line3,
                                 City = o.CustomerAddressBilling.Address.City,
                                 StateOrProvince = o.CustomerAddressBilling.Address.State,
                                 Zip = o.CustomerAddressBilling.Address.PostalCode,
                                 Country = o.CustomerAddressBilling.Address.Country,
                                 Latitude = o.CustomerAddressBilling.Address.Lat,
                                 Longitude = o.CustomerAddressBilling.Address.Long,
                                 Email = o.CustomerAddressBilling.Contact.ContactInfo,
                                 IsDefault = o.CustomerAddressBilling.IsPrimary
                             }
                         let cas = new Model.CustomerAddress
                             {
                                 Id = o.CustomerAddressShipping.CustAddId,
                                 UserName = o.User.UserName,
                                 FirstName = o.CustomerAddressShipping.Customer.FirstName,
                                 LastName = o.CustomerAddressShipping.Customer.LastName,
                                 MiddleInitial = o.CustomerAddressShipping.Customer.MiddleName,
                                 Salutation = o.CustomerAddressShipping.Customer.Salutation,
                                 Suffix = o.CustomerAddressShipping.Customer.Suffix,
                                 Street1 = o.CustomerAddressShipping.Address.Line1,
                                 Street2 = o.CustomerAddressShipping.Address.Line2,
                                 Street3 = o.CustomerAddressShipping.Address.Line3,
                                 City = o.CustomerAddressShipping.Address.City,
                                 StateOrProvince = o.CustomerAddressShipping.Address.State,
                                 Zip = o.CustomerAddressShipping.Address.PostalCode,
                                 Country = o.CustomerAddressShipping.Address.Country,
                                 Latitude = o.CustomerAddressShipping.Address.Lat,
                                 Longitude = o.CustomerAddressShipping.Address.Long,
                                 Email = o.CustomerAddressShipping.Contact.ContactInfo,
                                 IsDefault = o.CustomerAddressShipping.IsPrimary
                             }
                         let sm = new ShippingMethod
                            {
                                Id = o.ShippingMethod.ShippingMethodId,
                                Carrier = o.ShippingMethod.Carrier,
                                ServiceName = o.ShippingMethod.ServiceName,
                                BaseRate = o.ShippingMethod.BaseRate,
                                RatePerPound = o.ShippingMethod.RatePerPound,
                                DaysToDeliver = o.ShippingMethod.DaysToDeliver,
                                EstimatedDelivery = o.ShippingMethod.EstimatedDelivery
                            }
                         select new Model.Order
                             {
                                 Id = o.OrderId,
                                 UserName = o.User.UserName,
                                 DateCreated = o.CreateDate,
                                 Items = items.AsQueryable(),
                                 Transactions = transactions.AsQueryable(),
                                 ShippingAddressId = o.CustAddShippingId,
                                 BillingAddressId = o.CustAddBillingId,
                                 ShippingAddress = cas,
                                 BillingAddress = cab,
                                 ShippingMethod = sm,
                                 UserLanguageCode = "en",
                                 DateShipped = o.ShippedDate,
                                 EstimatedDelivery = o.EstimatedDelivery,
                                 TrackingNumber = o.TrackingNumber,
                                 TaxAmount = o.TaxAmount,
                                 DiscountReason = o.DiscountReason,
                                 DiscountAmount = o.DiscountAmount
                             };
            return orders;
        }
