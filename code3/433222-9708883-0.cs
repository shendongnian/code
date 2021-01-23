    string input = "John, Dog, 0, 00, 0, 0.00, 123";
    string[] items = string.Split(input, ",");
    for (i = 0; i < items.Length; i++)
    {
        if (items[i].Trim() == "0")
        {
            item[i].Replace("0", "0.00");
        }
    }
    string output = string.Join(items, ",");
