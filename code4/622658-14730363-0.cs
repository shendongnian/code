    bool allParsed = true;
    List<long> longList = new List<long>();
    foreach(object s in TheArrayList)
    {
        long val;
        if(Int64.TryParse(s, out val))
            longList.Add(val);
        else
        {
            allParsed = false;
            break;
        }
    }
    if(!allParsed)
        // handle the error
