    var fieldValues = new string[3];
    var currentField = 0;
    var line = "InternalNameA8ValueDisplay NameA¬InternalNameB8ValueDisplay NameB¬";
    
    foreach (var c in line)
    {
        if (c == '8' && currentField == 0)
        {
            currentField++; continue;
        }
    
        if (c == '¬')
        {
            currentField++; continue;
        }
    
        fieldValues[currentField] += c;
    }
