     if (cond.)
     {
         return new WrappedJsonResult   
         { 
                Data = new { IsValid = false,
                             Message = <error message>,
                             ImagePath =string.Empty
                           }
         }; 
    } 
