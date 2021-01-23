    HCFA_Claim c = new HCFA_Claim
        {
            Patient = new Patient
                {
                    FullName = ParseMapField(map.Name, cl),
                    Address = ParseMapField(map.Address, cl),
                }
        };
    
