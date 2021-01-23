    public static void Update(string p, int c)
    {
        // I'd suggest Dictionary, but don't know whether your strings are unique
        var recursionParameters = new List<KeyValuePair<string, int>>(); 
        
        using (SqlConnection conn = new SqlConnection("ConnectionString"))
        {
            ...
                        //do something else and runn the Update() again with some other parameters
                        //Update(x, y); Don't do it here! Instead:
                        recursionParameters.Add(new KeyValuePair<string, int>(x,y));
            ...
        }
        foreach (var kvp in recursionParameters
        {
            Update(kvp.Key, kvp.Value)
        }
    }
