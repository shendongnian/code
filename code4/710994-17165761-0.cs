    return UnitOfWork.DbContext.PAddresses.SingleOrDefault(x => x.PId == sid)
           .Select(x => new AddressViewModel
           {
               PId = sid,
               AddressLine1 = x.Address.AddressLine1,
               AddressLine2 = String.Compare(x.Address.AddressLine2, x.Address.Suburb.Name, StringComparison.OrdinalIgnoreCase) == 0 ? null : x.Address.AddressLine2,
               Suburb = x.Address.Suburb.Name,
           });
