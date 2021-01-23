    Type type = typeof(Fields); // MyClass is static class with static properties
    foreach (var p in type.GetProperties())
    {
       var v = p.GetValue(null, null); // static classes cannot be instanced, so use null...
       //do something with v
    }
