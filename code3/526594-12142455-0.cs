    var model = _serviceRepository.GetProducts()
        .AsEnumerable()
        .Select(p => new ProductModel
                         {
                             Id = p.Id,
                             Name = p.Name,
                             Credits = p.Credits,
                             Months = p.Months,
                             Price = p.Price,
                             PayPalButton = GenerateSubscriptionButton(p.Id)
                         });
