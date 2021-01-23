    var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
    var properties = 
       from p in this._context.GetType().GetProperties(flags)
       where (p.GetIndexParameters().Length == 0) && 
             (p.DeclaringType != typeof(DbContext))
       select p);
 
    foreach(PropertyInfo info in properties)
    {
        // ...
    }
