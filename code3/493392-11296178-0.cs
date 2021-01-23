    var collection = _productService.GetAllProduct().Select(x =>
                new ProductModel()
                {
                    ProductId = x.ProductId,
                    Title = x.Title,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    Barcode = x.Barcode,
                    AlarmPoint = x.AlarmPoint.Value,
                    MeasurementId = x.MeasurementId,
                    Length = x.Length.Value,
                    Breadth = x.Breadth.Value,
                    Height = x.Height.Value,
                    Weight = x.Weight.Value,
                    IsActive = x.IsActive.Value,
                    IsSellable = x.IsSellable.Value,
                    IsPurchasable = x.IsPurchasable.Value
                });
