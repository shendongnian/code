    public class CustomerAddressMap : ClassMap<CustomerAddress>
    {
        public CustomerAddressMap()
        {
            Table("CustomerAddress");
            Id(x => x.CustomerAddressId);
            Map(x => x.FromDate).Not.Nullable();
            Map(x => x.ToDate);
            References(x => x.Customer, "CustomerId");
            References(x => x.Address, "AddressId");
        }
    }
