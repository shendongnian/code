    Type type = result.GetType();
    PropertyInfo[] properties = type.GetProperties();
    foreach (PropertyInfo property in properties)
    {
        string prs = property.GetMethod.ToString();
        if(!prs.StartsWith("System"))
        {
            //IS CLass
        } else {
           Console.WriteLine(property.Name + ":::" + property.Value);
        }
    }
