    // we know how many values can be in char.
    int[] values = new int[char.MaxValue];
    
    // do the counts.
    for (int i = 0; i < text.Length; i++)
        values[text[i]]++;
    
    // Display the results.
    for (char i = char.MinValue; i < char.MaxValue; i++)
        if (values[i] > 0)
           Debug.WriteLine("{0} = {1}", i, values[i]);
