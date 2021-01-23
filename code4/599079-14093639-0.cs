    public static class AddressExtensions
    {
        public static Address DeliveryAddress(this IEnumerable<Address> addresses)
        {
            return addresses.SingleOrDefault(x => x.TypeId == AddressType.Delivery) 
                   ?? new Address();
        }
    
        public static Address InvoiceAddress(this IEnumerable<Address> addresses)
        {
            return addresses.SingleOrDefault(x => x.TypeId == AddressType.Invoice) 
                   ?? new Address();
        }
    }
