     public int? MethodWithSomeReturnValue()
     {
        //return null in failure case
     }
    
     int? result = MethodWithSomeReturnValue();
     if(result != null)
     {
       //...
     }
