    var agencyContracts = _agencyContractsRepository.AgencyContracts
        .GroupBy(ac => new
                       {
                           ac.AgencyContractID, // required by your view model. should be omited
                                                // in most cases because group by primary key
                                                // makes no sense.
                           ac.AgencyID,
                           ac.VendorID,
                           ac.RegionID
                       })
        .Select(ac => new AgencyContractViewModel
                       {
                           AgencyContractID = ac.Key.AgencyContractID,
                           AgencyId = ac.Key.AgencyID,
                           VendorId = ac.Key.VendorID,
                           RegionId = ac.Key.RegionID,
                           Amount = ac.Sum(acs => acs.Amount),
                           Fee = ac.Sum(acs => acs.Fee)
                       });
