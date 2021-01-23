    public static CallerClass
    {
        public static CallGenericOverload<T>(GenericClass<T> cls, T val)
        {
            return cls.ProblemOverload(val); 
        }   
  
        //We can also make an extension method. 
        //We don't have to of course, it's just more comfortable this way.
        public static CallGenericOverloadExtension<T>(this GenericClass<T> cls, T val)
        {
            return cls.ProblemOverload(val);
        }
    
    }
    
    public GenericClass<T>
    {
         public string ProblemOverload(T val)
         {
             return "ProblemOverload(T val)";
         }
         public string ProblemOverload(string val)
         {
             return "ProblemOverload(string val)";
         }
    }
