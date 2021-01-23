    using System.Runtime.Caching;
    
    ...
    
    ObjectCache cache = MemoryCache.Default;
    var test = "hello world";
    cache["greeting"] = test;
    var greeting = (string)cache["greeting"];
