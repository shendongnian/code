    public class Order
    {
        public string OrderProperty { get; set; }
        public Address OrderAddress { get; set; }
    }
    
    public class Address
    {
        public string AddressProperty { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var order = new Order
            {
                OrderProperty = " order to trim ",
                OrderAddress = new Address
                {
                    AddressProperty = " address to trim "
                }
            };
    
            TrimObjectValues(order);
            Console.WriteLine("'{0}', '{1}'", order.OrderProperty, order.OrderAddress.AddressProperty);
        }
    
        static void TrimObjectValues(object instance)
        {
            if (instance == null)
            {
                return;
            }
    
            var props = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                // Ignore non-string properties
                    //.Where(prop => prop.PropertyType == typeof(string) || prop.PropertyType == typeof(object))
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
