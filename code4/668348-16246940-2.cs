    YourStudent s1;
    TheirStudent s2;
    Type t = typeof(YourStudent);
    Type t2 = typeof(TheirStudent);
    foreach (PropertyInfo pinfo in t.GetProperties()) 
    {
        if (pinfo.GetGetMethod().IsVirtual &&
            pinfo.PropertyType.IsGenericType &&
            pinfo.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
        {
            // This is [probably] a nav property. Courses would be in here
        }
        else if (pinfo.GetGetMethod().IsVirtual)
        {
            // if you have 0..1 or 1..1 nav properties you might muck around in here
        }
        else if (!pinfo.GetGetMethod().IsVirtual)
        {
            // This is [probably] a column - studentId, name, etc would be here
            // you could pull values over like so:
            PropertyInfo pinfo2 = (from ps in t2.GetProperties() 
                                   where ps.Name == pinfo.Name 
                                   select ps).SingleOrDefault();
            if (pinfo2 != null)
            {
                object value = pinfo2.GetValue(s2, new object[] { });
                pinfo.SetValue(s1, value, new object[] { });
            }
        }
    }
