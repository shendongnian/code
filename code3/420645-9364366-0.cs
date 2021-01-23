    // Get all public or private non-static properties declared in this class
    // (e.g. excluding inherited properties) that have a getter and setter.
    PropertyInfo[] props = this.GetType()
        .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                       BindingFlags.Public | BindingFlags.NonPublic)
        .Where(p => p.GetGetMethod(true) != null && p.GetSetMethod(true) != null)
        .ToArray();
