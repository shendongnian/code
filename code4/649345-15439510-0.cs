    PropertyInfo[] myProperties = c.GetType().GetProperties(BindingFlags.Public |
                                                        BindingFlags.SetProperty |
                                                        BindingFlags.Instance);
    
    foreach (PropertyInfo item in myProperties)
    {
        if (item.CanRead)
            Console.Write("Can read");
    
        if (item.CanWrite)
            Console.Write("Can write");
    }
