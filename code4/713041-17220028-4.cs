    int n = 0;
    Type[] types = Assembly.GetExecutingAssembly().GetTypes();
    foreach (Type type in types)
    {
        if (type.IsSubclassOf(typeof(Parent)))
        {
             dict["key" + n] = type;
             n++;
        }
    }
