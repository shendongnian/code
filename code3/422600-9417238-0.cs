    foreach(var expression in propertiesToDoStuffWith)
    {
         var result = expression.Compile()(item);
    
         if (result is ICollection){
              // handle collection type
         }
         else {
              // some other type
         }
    }
