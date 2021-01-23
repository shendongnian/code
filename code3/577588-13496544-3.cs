     public static object JsonSeralize(object obj)
       {
          Debug.Assert(!obj.getType().IsAnonymousType());     
          return JsonConvert.SerializeObject(obj);
       }
