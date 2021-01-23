    foreach (var property in yourObject.GetType().GetProperties())
    {
        if (property.GetType().GetInterfaces().Contains(typeof(IEnumerable<>)))
        {
            foreach (var item in (IEnumerable)property.GetValue(yourObject, null))
            {
                 //do stuff
            }
        }
    }
