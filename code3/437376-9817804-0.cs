    public T GetFromQueryString<T>() where T : new(){
        var obj = new T();
        var properties = typeof(T).GetProperties();
        foreach(var property in properties){
            var valueAsString = HttpContext.Current.Request.QueryString[property.PropertyName];
            var value = Parse( valueAsString, property.PropertyType);
            
            if(value == null)
                continue;
            
            property.SetValue(obj, value, null);
        }
        return obj;
     }
