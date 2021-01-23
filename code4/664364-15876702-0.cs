    string input = "1234ABCD-1A-AB";
    char separator = '-';
    string[] parts = input.Split(separator);
    
    // if you do not need to know the item index:
    foreach (string item in parts)
    {
        // do something here with 'item'
    }
    // if you need to know the item index:
    for (int i = 0; i < parts.Length; i++)
    {
        // do something here with 'item[i]', where i is 
        // the index (so 1, 2, or 3 in your case).
    }
