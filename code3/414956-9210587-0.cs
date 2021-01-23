        Location local = new Location();
        local.city = "Lisbon";
        local.country = "Portugal";
        local.state = "None";
        PropertyInfo[] infos = local.GetType().GetProperties();
        Dictionary<string,string> dix = new Dictionary<string,string> ();
        foreach (PropertyInfo info in infos)
        {
            dix.Add(info.Name, info.GetValue(local, null).ToString());
        }
        foreach (string key in dix.Keys)
        {
            Console.WriteLine("nameProperty: {0}; value: {1}", key, dix[key]);
        }
        Console.Read();
