    PropertyInfo[] props = this.GetType()
        .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                       BindingFlags.Public | BindingFlags.NonPublic)
        .Where(p => p.CanRead && p.CanWrite)
        .ToArray();
