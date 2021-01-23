    var keyValue = new Dictionary<string, string>();
    foreach (var lineItem in System.IO.File.ReadAllLines(@"C:\Users\Kane\Desktop\yourFile.txt").Where(x => x.Contains(": ")))
    {
        var splitPosition = lineItem.IndexOf(": ", System.StringComparison.OrdinalIgnoreCase);
        var key = lineItem.Substring(0, splitPosition);
        var value = lineItem.Substring(splitPosition + 1);
            
        // add in functions for checking null
        // add in functions for trimming
        // add in special cases for 
        keyValue.Add(key, value);
    }
