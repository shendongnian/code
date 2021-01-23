    public static string TestFunction(object obj)
    {
        //To dictionary
        //var dict = obj.GetType().GetProperties()
        //                .ToDictionary(p=>p.Name,p=>p.GetValue(obj,null));
        //Directly ToString
        string result = String.Join(",", obj.GetType().GetProperties()
                                            .Select(p=>p.Name + ":" + p.GetValue(obj,null)));
        return result;
    }
