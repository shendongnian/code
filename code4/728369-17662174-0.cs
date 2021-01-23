        foreach (var attrib in Attribute.GetCustomAttributes(type))
        {
            if (attrib.GetType().Name == "Table")
            {
                Console.WriteLine(attrib.GetType().FullName);
            }
        }
