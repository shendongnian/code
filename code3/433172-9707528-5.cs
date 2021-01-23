    public enum OrderType
    {
        OnOrBefore
    }
    
    public class Order
    {
        public string OrderUniqueIdentifier { get; set; }
        public string VendorName { get; set; }
        public string SoldToCustomerID { get; set; }
        public OrderType OrderType { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Address ShipToAddress { get; set; }
    }
    
    public class Address
    {
        public string AddressID { get; set; }
        public string OrganizationName { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            Order o = new Order();
    
            o.OrderUniqueIdentifier = "TYBDEU83e4e4Ywow";
    
            o.VendorName = "Kwhatever";
            o.SoldToCustomerID = "Abc98971";
            o.OrderType = OrderType.OnOrBefore;
            o.CustomerPurchaseOrderNumber = "MOOMOO 56384";
            o.EmailAddress = "abc@electric.com";
            o.DeliveryDate = DateTime.Now.AddDays(35);
    
            Address address1 = new Address();
            //address1.AddressID = "Z0mmn01034";
            address1.AddressID = "E0000bbb6                         ";
            address1.OrganizationName = "                                       Nicks Organization ";
            address1.AddressLine1 = "              143 E. WASHINGTON STREET                ";
            address1.City = "          Rock        ";
            address1.State = "MA                       ";
            address1.ZipCode = "                         61114";
            address1.Country = "US                ";
    
            o.ShipToAddress = address1;
    
    
            TrimObjectValues(o);
        }
    
        static void TrimObjectValues(object instance)
        {
            if (instance == null)
            {
                return;
            }
    
            var props = instance
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                // Ignore indexers
                .Where(prop => prop.GetIndexParameters().Length == 0)
                // Must be both readable and writable
                .Where(prop => prop.CanWrite && prop.CanRead);
    
            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType == typeof(string))
                {
                    string value = (string)prop.GetValue(instance, null);
                    if (value != null)
                    {
                        value = value.Trim();
                        prop.SetValue(instance, value, null);
                    }
                }
                else
                {
                    TrimObjectValues(prop.GetValue(instance, null));
                }
            }
        }
    }
