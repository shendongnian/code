    public IEnumerable<AddressViewModel> GetAddress (long sid)
    {
        var data = UnitOfWork.DbContext.PAddresses.Where(x => x.PId == sid)
                             .Select(x => new AddressViewModel
                                          {
                                              PId = sid,
                                              AddressLine1 = x.Address.AddressLine1,
                                              AddressLine2 = x.Address.AddressLine2.ToLower() == x.Address.Suburb.Name.ToLower() ? null : x.Address.AddressLine2,
                                              Suburb = x.Address.Suburb.Name,
                                          });
        return data;
    }
