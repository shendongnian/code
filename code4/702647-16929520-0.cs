    from customer in bd.Customers
    group customer by new { TrimmedPostalCode = customer.postalcode.Substring(0, postalCodeLength), customer.CustomerGroupType}
    into postalCodes
    select new PostalCode 
    { 
        Postal = postalCodes.Key.TrimmedPostalCode,
        CustomerGroupType = postalCodes.Key.CustomerGroupType,
        Count = postalCodes.Count() 
    }
