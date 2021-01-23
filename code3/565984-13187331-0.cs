    var serializer = new JavaScriptSerializer();
    var rows = db.GetOrderHistoryByUserId(id);
    var json = serializer.Serialize(new { Orders = rows.GroupBy(o => o.Number)
                                            .Select(g =>
                                                    new
                                                        {
                                                            OrderNumber = g.Key,
                                                            OrderTotal = g.Sum(o => o.Price),
                                                            Products = g.Select(
                                                                o => new {SKU = o.Sku, ProductPrice = o.Price}
                                                        )
                                                    }
                                        )});
