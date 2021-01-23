    foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
    {
        foreach (var type in assem.GetTypes())
        {
            foreach (var prop in type.GetProperties())
            {
                if (!prop.CanRead)
                    Console.WriteLine("Assembly: {0}; Type: {1}; Property: {2}", assem.FullName, type.Name, prop.Name);
            }
        }
    }
