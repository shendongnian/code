    public static void ParseData(object source)
    {
        Dictionary<string, object> Dict;
        KeyValuePair<string, object> Kvp;
        if ((Dict = source as Dictionary<string,object) != null)
        {
            foreach(var kvp in Dict)
            {
                Console.WriteLine(kvp.Key);
                ParseData(kvp.Value);
            }
        }
        elseif ((Kvp = source as KeyValuePair<string, object>) != null)
        {
            Console.WriteLine("{0}{1}", Kvp.Key, Kvp.Value);
        }
    }
