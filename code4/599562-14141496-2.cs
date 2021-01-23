    private static List<Type> CommonTypesPriorities = new List<Type> 
                                           {
                                               typeof(IEnumerable), 
                                               typeof(Array), 
                                               typeof(IClonable)
                                           };
 
    public static Type FindEqualTypeWith(this Type type1, Type type2)
    {
        if(type1 == type2) 
            return type1;
        var baseClass = type1.FindBaseClassWith(type2);
 
        //if the base class is not object/interface and it is not in the list, then return it.
        if(baseClass != typeof(object) && baseClass != null && !CommonTypesPriorities.Contains(type))
            return baseClass;
        var @interface = type1.FindInterfaceWith(type2);
        if(@interface == null)
            return baseClase;
        
        //if there's no base class and the found interface is not in the list, return it
        if(baseClass != null && !CommonTypesPriorities.Contains(@interface)                         
            return @interface;
        //Now we have some class and interfaces from the list.
        Type type = null;
        int currentPriority;
        //if the base class is in the list, then use it as the first choice
        if(baseClass != null && CommonTypesPriorities.Contains(type))
        {
            type = baseClass;
            currentPriority = CommonTypesPriorities.IndexOf(type);
        }
        var interfaces1 = type1.GetInterfaces();
        var interfaces2 = type2.GetInterfaces();
 
        foreach(var i in interfaces1)
        {
            if(interfaces2.Contains(i))
            {
                //We found a common interface. Let's check if it has more priority than the current one
                var priority = CommonTypesPriorities.IndexOf(i);
                if(i >= 0 && i < currentPriority)
                {
                    currentPriority = priority;
                    type = i;
                }
            }
        }
        return type;
