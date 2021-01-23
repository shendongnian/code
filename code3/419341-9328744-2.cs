    public Class Factory
    {
         public static object CreateAndRegister(string className)
         {
             Assembly assem = Assembly.GetExecutingAssembly();
             assem.CreateInstance(className, false);
            
             //Code for registration          
             
             return obj;
         }
    }
