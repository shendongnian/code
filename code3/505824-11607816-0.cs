    string[] myList = new ArrayList();
    Dictionary<object, int> counts = new Dictionary<object,int>();
    foreach (object item in myList)
    {
        if (!counts.ContainsKey(item))
        {
           counts.Add(item,1);
        }
        else
        {
           counts[item]++; // this count contains the expected values, i want to display in label
        }
    
    }
     
    label.Tex = string.Join(" ", counts.Select(obj => obj.Value).ToList())); //if you need dictionary values
    label.Tex = string.Join(" ", counts.Select(obj => obj.Key).ToList())); //if you need dictionary keys
    label.Tex = string.Join(" ", counts); //to display the key-value combo as such.
