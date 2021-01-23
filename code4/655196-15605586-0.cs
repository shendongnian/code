    var agencyContracts = _agencyContractsRepository.AgencyContracts
        .GroupBy(ac => new
                       {
                           ac.AgencyContractID,
                           ac.AgencyID,
                           ac.VendorID,
                           ac.RegionID
                       })
        .Select(ac => new AgencyContractViewModel
                       {
                           AgencyContractId = ac.AgencyContractID,
                           AgencyId = ac.AgencyID,
                           VendorId = ac.VendorID,
                           RegionId = ac.RegionID,
                           Amount = ac.Sum(acs => acs.Amount),
                           Fee = ac.Sum(acs => acs.Fee)
                       });
