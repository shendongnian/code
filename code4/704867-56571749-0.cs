 lang c#
    pubic class SomeClass
      
        public dynamic DomainFunction(
            object countryVal = null
          , object cityVal = null
          , object key = null
          , object page = null
        )
        {
            dynamic obj = new ExpandoObject();
    
            cityVal?.Tee(x => obj.City = x);
            countryVal?.Tee(x => obj.Country = x);
            key?.Tee(x => obj.Keyword = x);
            page?.Tee(x => obj.Page = x);
    
            return obj;
        }
    
    }
    
    public static class FunctionalExtensionMethods{
    
    	public static T Tee<T>(this T source, Action<T> action)
        {
          if (action == null)
            throw new ArgumentNullException(nameof (action));
          action(source);
          return source;
        }
    
    }
