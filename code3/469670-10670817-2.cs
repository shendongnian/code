    string value = "Fruit Tasty Brand Apples 3";
    int index1 = value.LastIndexOf(' ');
    if (index1 != -1)
    {
        Console.WriteLine(index1);
        Console.WriteLine(value.Substring(index1)); // 3
        Console.WriteLine(value.Substring(0, index1-2)); // Fruit Tasty Brand Apples
    }
