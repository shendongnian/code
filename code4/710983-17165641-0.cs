        public IEnumerable<AddressViewModel> GetAddress (long sid)
                {
                    PAddresses data = UnitOfWork.DbContext.PAddresses.Where(x => x.PId == sid)
                                         .Select(x => new AddressViewModel
                                             {
                                                 PId = sid,
                                                 AddressLine1 = x.Address.AddressLine1,
                                                 AddressLine2 = x.Address.AddressLine2,
                                                 Suburb = x.Address.Suburb.Name,
                                             }).singleordefault();
                  
    if(data != null )
    {
     data.ElementAt(i).AddressLine2 = null;  data.ElementAt(i).AddressLine3 = null;
    
    }
                    return data;
            }
