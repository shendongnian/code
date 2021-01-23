    // Get Properties via Reflection
    List<PropertyInfo> personProperties = new List<PropertyInfo>();
    Type personType = typeof(Person);
    foreach(string member in members)
    {
        PropertyInfo prop = peopleType.GetProperty(member);
        if(prop != null)
        {
            if (people.Select(p => prop.GetValue(p, null) ).Distinct().Count() == 1)
            {
                prop.SetValue(unionMan, prop.GetValue(people[0], null), null);
            }
        }
    }
    
