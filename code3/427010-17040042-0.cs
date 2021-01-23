    Type type = typeof(DbContext).Assembly.GetType("System.Data.Entity.Internal.LazyInternalContext");
    var field = type.GetField("DefaultCodeFirstInitializer", BindingFlags.NonPublic | BindingFlags.Static);
    if (field != null)
        field.SetValue(null, null);
    else
    {
        var field2 = type.GetField("_defaultCodeFirstInitializer", BindingFlags.NonPublic | BindingFlags.Static);
        if (field2 != null)
            field2.SetValue(null, null);
