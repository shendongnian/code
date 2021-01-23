     public AddressMap()
     {
        Schema("dbo");
        Table("Address");
        Id(x => x.AddressId);
        Map(x => x.AddressType);
        HasOne(x => x.CustomerAddress).Cascade.All();
     }
     public CustomerAddressMap()
     {
         Schema("dbo");
         Table("CustomerAddress");
         Id(x => x.CustomerAddressId);
         Map(x => x.FromDate)
             .Not.Nullable();
         Map(x => x.ToDate);
         HasOne(x => x.Address)
         .Constrained()
         .ForeignKey();
     }
