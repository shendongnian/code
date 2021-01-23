    var agencyContracts = _agencyContractsRepository.AgencyContracts
        .GroupBy(ac => new
                       {
                           ac.AgencyID,
                           ac.VendorID,
                           ac.RegionID
                       })
        .Select(ac => new AgencyContractViewModel
                       {
                           AgencyId = ac.Key.AgencyID,
                           VendorId = ac.Key.VendorID,
                           RegionId = ac.Key.RegionID,
                           Total = ac.Sum(acs => acs.Amount) + ac.Sum(acs => acs.Fee)
                       });
