    public static IList<string> GetDescriptions<E>(E type)
    {
        //I'm not going to do your error checking for you. 
        //Figure out what you want to do in the event that this isn't an enumeration. 
        //Or design it to support different cases. =P
        var list = new List<string>(); 
        foreach(var name in Enum.GetNames(typeof(E)))
        {
            var enumObj = (E) Enum.Parse(typeof(E), name);
            list.Add(enumObj.GetDescription());
        }
        return list;
    }
