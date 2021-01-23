    foreach (var customer in customers)
    {
        foreach (var property in typeof(Customer).GetProperties())
        {
            var attributes = property.GetCustomAttributes(false);
            var attr = Attribute.GetCustomAttribute(property, typeof(ShowAttribute)) as ShowAttribute;
            if (attr != null)
            {
                Console.WriteLine(property.GetValue(customer, null));
            }
        }
    }
