    var myObject = new MyObjectType() { prop1 = "string 1", prop2 = 1 };
    var cacheKey = "mycachekey";
    var cTime = DateTime.Now.AddMinutes(11);
    var cExp = System.Web.Caching.Cache.NoSlidingExpiration;
    var cPri = System.Web.Caching.CacheItemPriority.Normal;
 
    HttpContext.Current.Cache.Add(cacheKey, myObject, null, cTime, cExp, cPri, null);
    myObject.prop1 = "string 2"; myObject.prop2 = 2;
    HttpContext.Current.Cache.Add(cacheKey, myObject, null, cTime, cExp, cPri, null);
    myObject.prop1 = "string 3"; myObject.prop2 = 3;
    HttpContext.Current.Cache.Insert(cacheKey, myObject, null, cTime, cExp, cPri, null);
    myObject.prop1 = "string 4"; myObject.prop2 = 4;
    HttpContext.Current.Cache.Insert(cacheKey, myObject, null, cTime, cExp, cPri, null);
    myObject.prop1 = "string 5"; myObject.prop2 = 5;
    HttpContext.Current.Cache.Add(cacheKey, myObject, null, cTime, cExp, cPri, null);
    myObject.prop1 = "string 6"; myObject.prop2 = 6;
    HttpContext.Current.Cache.Insert(cacheKey, myObject, null, cTime, cExp, cPri, null);
    var foo = (MyObjectType)HttpContext.Current.Cache[cacheKey];
