    Type t = input.GetType();
    PropertyInfo[] properties = t.GetProperties(
        BindingFlags.NonPublic | // Include protected and private properties
        BindingFlags.Public | // Also include public properties
        BindingFlags.Instance // Specify to retrieve non static properties
        );
