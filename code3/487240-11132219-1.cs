        var d = clist.ToDictionary
            (k => k.CountryID.ToString(),
             e => e.States.ToDictionary(k2 => k2.StateID.ToString(),
                                        e2 => e2.StateName));
        Console.WriteLine("{0}",JSONHelper.ToJSON(d));
