    public DateTime InsertItemOnCache(object item, DateTime expiration){
    
    DateTime dateExpiration;
    //Here you construct your cache key. 
    //You can use your asp.net sessionID if you want to your cache 
    //to be for a single user.
    var key = string.format("{0}--{1}", "Test", "NewKey");
    
    if (expiration!= null)
      dateExpiration = expiration;
    }else{
      //Set your default time
      dateExpiration = DateTime.Now.AddHours(4);
    }
    //I recommend using Insert over Add, since add will return null if there are
    //2 objects with the same key
    HttpContext.Current.Cache.Insert(key, item, null, dateExpiration, Cache.NoSlidingExpiration);
    
    return dateExpiration;
    }
