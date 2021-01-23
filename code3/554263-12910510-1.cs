    // group the cartItems according to location
            List<ViewInvoice> ordersGrouped = cartItems.GroupBy(c => new 
                {c.ClientLocation})
                .OrderBy(c => c.Key.ClientLocation).Select(s =>
                    new ViewInvoice()
                        {
                            ClientLocation = s.Key.ClientLocation,
                            Product = s.Select(p => p.Product).ToList(),
                            ItemQuantity = s.Select(p => p.ItemQuantity).ToList(),
                            DeliveryDate = s.Select(p => p.DeliveryDate).ToList(),
                            OrderDate = s.Select(p => p.OrderDate).ToList(),
                            OrderNumber = s.Select(p => p.OrderNumber).ToList(),
                            PackageType = s.Select(p => p.PackageType).ToList(),
                            Price = s.Select(p => p.Price).ToList(),
                            ProductSize = s.Select(p => p.ProductSize).ToList()
                        }).ToList();
