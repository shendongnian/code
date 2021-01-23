    static HashTable GetTown(string town)
    {
        Hashtable hashtable;
        switch(town)
        {
            case "Edinburgh":
                hashtable = new Hashtable();
                hashtable.Add("Aberdeen", 129);
                hashtable.Add("Ayr", 79);
                hashtable.Add("Fort_William", 131);
                hashtable.Add("Glasgow", 43);
                hashtable.Add("Inverness", 154);
                hashtable.Add("St_Andrews", 50);
                hashtable.Add("Stirling", 36);
                break;
                // Other cases here
        }
        return hashtable;
    }
