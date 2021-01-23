    foreach (var property in yourObject.GetType().GetProperties())
    {
        if (property.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
        {
            foreach (var item in (IEnumerable)property.GetValue(yourObject, null))
            {
                 //do stuff
            }
        }
    }
