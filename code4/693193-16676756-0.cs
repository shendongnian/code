        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(response))
        {
            string name = descriptor.Name;
            object value = descriptor.GetValue(response);
            Console.WriteLine("{0}={1}", name, value);
            if (name.Contains("StatusData"))
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(value))
                {
                   ...
                }
            }
        }
