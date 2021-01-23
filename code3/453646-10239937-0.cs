    var ms = (from detail in this.Context.ShippingDocumentDetails
                        join header in this.Context.ShippingDocuments on detail.ClientOrderNumber equals header.ClientOrderNumber
                        where (header.DateOrdered >= imqp.StartDate)
                         && (header.DateOrdered <= imqp.EndDate)
                        orderby header.DateOrdered descending
                        select new ItemMovement(long.Parse(ConfigurationManager.AppSettings["PickedOrderSourceSystem"]),
                            ItemMovementKind.Picked,
                            ((header.DateOrdered.HasValue) ? header.DateOrdered.Value : new DateTime(1900, 1, 1)),
                             UniversalItemMovementConverter.GetMovementKeyFromShippingDocument(header.ClientOrderNumber),
                            detail.ProductCode,
                            header.ClientOrderNumber,
                            string.Empty,
                            ((detail.QuantityDelivered.HasValue) ? detail.QuantityDelivered.Value : 0)) { }).ToList();
                this.UpdateItemMovements(ms);
                register.AddRange(ms);
