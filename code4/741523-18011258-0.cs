    public void AddRange(string value) {
      var converter = TypeDescriptor.GetConverter(typeof(T));
    
      if (!Object.Reference(converter, null))
        if (converter.CanConvertFrom(typeof(String)) {
          T result = (T) converter.ConvertFrom(value);
          // value is converted to T; your code here   
          ...
          return; 
        } 
    
      // Type T can't be obtained from String directly
      //   1. Do it using by-ways (spesific for particular T's)
      //   2. Use default(T)  
      //   3. Throw exception
      ... 
