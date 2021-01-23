    var result = MCDBContext.Customers
        .Where(customer => customer.IsActive && customer.CustomerPIN.Equals(
               pin, StringComparison.InvariantCultureIgnoreCase)
            && customer.CustomerCases.Any(ccase =>
                   ccase.IsActive
                && ccase.CustomerCasePhones.Any(phone => 
                       phone.IsActive
                    && phone.PhoneNumber.Equals(
                       phoneNumber, StringComparison.InvariantCultureIgnoreCase))
                && ccase.CustomerCaseAddresses.Any(address =>
                       address.IsActive
                    && address.AddressTypeID == 6)))
        .Select(customer => new
        {
            Customer = customer,
            // you can also fetch here cases and phones, if you need them
            Addresses = customer.CustomerCases.Where(ccase => ccase.IsActive)
                .Select(ccase => ccase.CustomerCaseAddresses
                   .Where(address => address.IsActive && address.AddressTypeID == 6))
        })
        .ToList();
