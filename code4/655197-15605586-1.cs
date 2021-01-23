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
                           Amount = ac.Sum(acs => acs.Amount),
                           Fee = ac.Sum(acs => acs.Fee)
                       });
