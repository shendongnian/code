    foreach (var prop in userInfo.GetType().GetProperties())
    {
        Console.WriteLine("Property name: " + prop.Name);
        Console.WriteLine("Property value: " + prop.GetValue(userInfo, null));
    }
