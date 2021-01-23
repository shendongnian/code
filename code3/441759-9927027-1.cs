    var key = inputBx.Text; // Let us say "White"
    
    if (myDictionary.ContainsKey(key))
    {
    
        var targetColor = myDictionary[key]; // Just get the value
    
        outputBx.Select(0, targetColor.Item1.Length);
        outputBx.SelectionColor = targetColor.Item2;
        outputBx.Text = targetColor.Item1;
    }
    else
    {
        outputBx.Text = "Unknown";
    }
