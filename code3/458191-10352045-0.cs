     public bool ImplementsIFooOnly(Type type)
     {
         return !type.GetInterfaces().Any(t => 
                  { 
                       return t is IFoo && !t.Equals(typeof(IFoo)); 
                  });
     }
