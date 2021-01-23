    string input = "John, Dog, 0, 00, 0, 0.00, 123";
    string[] items = input.Split(",");
    
    for (int i = 0; i < items.Length; i++)
    {
        int intValue;
        if (Int32.TryParse(items[i].Trim(), out intValue))
        {
            if (intValue == 0)
                items[i] = intValue.ToString("f2");
        }
    }
    
    string output = string.Join(items, ", ");
