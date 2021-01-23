    Models.TestModels obj = new Models.TestModels();
    foreach (var item in obj.sp)
    {
        Console.Write(item.Key);
        Console.Write(item.Value.name);
        Console.Write(item.Value.age);
    }
