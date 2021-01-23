    Type personType = typeof(Person);
    foreach(string member in members)
    {   // Get Fields via Reflection
        FieldInfo field = peopleType.GetField(member);
        if(field != null)
        {
		    if (people.Select(p => field.GetValue(p, null) ).Distinct().Count() == 1)
            {
                field.SetValue(unionMan, field.GetValue(people[0], null), null);
            }
        }
        else // If member is not a field, check if it's a property instead
        {   // Get Properties via Reflection
            PropertyInfo prop = peopleType.GetProperty(member);
            if(prop != null)
            {
                if (people.Select(p => prop.GetValue(p, null) ).Distinct().Count() == 1)
                {
                    prop.SetValue(unionMan, prop.GetValue(people[0], null), null);
                }
            }
        }
    }
