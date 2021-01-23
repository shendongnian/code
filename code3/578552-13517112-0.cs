    .CheckReference(
            c => c.Proposal,
            new Proposal
                {
                    IsDeleted = false,
                    TenantId = 1,
                    VersionNumber = 1,
                    OutletId = 1,
                    StatusId = "TST"
            })
