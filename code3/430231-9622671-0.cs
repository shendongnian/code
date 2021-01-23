    MyObject GetMyObject()
    {
      MyObject result= cacheProvider.Get("cacheId_MyObject");
      if (result = null)
      { 
        result = VerySlowMethodToCreateMyObject();
        cacheProvider.Cache("cacheId_MyObject", result);
      }
      return result;
    }
