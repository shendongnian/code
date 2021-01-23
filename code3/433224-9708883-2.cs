    string input = "John, Dog, 0, 00, 0, 0.00, 123";
    string[] items = input.Split(",");
    for (int i = 0; i < items.Length; i++)
    {
        string value = items[i].Trim();
        int converted;
        
        if (int.TryParse(value, out converted))
        {
            if (converted == 0)
            {
                items[i].Replace(value, "0.00");
            }
        }        
    }
    string output = string.Join(items, ",");
