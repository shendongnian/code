    view.Cast<IEntity2>()
        .Select(c => new A1AllocationHelp1TableDTO
               {
                   RecordStatus = c.RecordStatus,
                   UniqueIdent = c.UniqueIdent
               })
        .ToList();
