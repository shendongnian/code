    public static T ConstructFromAnonymous<T>(object anon)
    {
        //get constructors for type ordered by number of parameters
        var constructors = typeof(T).GetConstructors().OrderByDescending(c => c.GetParameters().Length);
    
        //get properties from anonymous object
        Dictionary<string, PropertyInfo> properties = anon.GetType()
            .GetProperties()
            .ToDictionary(p => p.Name);
    
        ConstructorInfo bestMatch = constructors.FirstOrDefault(ci => IsMatch(ci, properties));
        if (bestMatch != null)
        {
            var parameters = bestMatch.GetParameters();
            object[] args = parameters.Select(p => properties[p.Name].GetValue(anon, null)).ToArray();
            return (T)bestMatch.Invoke(args);
        }
        else throw new ArgumentException("Cannot construct type");
    }
    
    private static bool IsMatch(ConstructorInfo ci, Dictionary<string, PropertyInfo> properties)
    {
        var parameters = ci.GetParameters();
        return parameters.All(p => properties.ContainsKey(p.Name) && p.ParameterType.IsAssignableFrom(properties[p.Name].PropertyType));
    }
