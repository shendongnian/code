    public someReturnType DoSomething(object myObject)
    {
      if (null == myObject)
      { 
        throw new ArgumentNullException("myObject");
      }
    
      var propertyA = myObject.GetType().GetProperty("propertyA");
      if (null == propertyA)
      {
        //this object doesn't have any property called "propertyA".
        //throw some error if needed
      }
    
      var value = propertyA.GetValue(myObject); //You will need to cast as proper expected type
    
      // You can retrieve propertyB similarly by searching for it through GetProperty call.
      // Once you have both A and B, 
      // you can work with values and return your output as needed.
    
      return something;
    }
