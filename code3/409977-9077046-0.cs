    class Example 
    {
        static void ShowTypeInfo (object o) 
        {  
            Console.WriteLine ("type name = {0}, 
                                full type name = {1}", o.GetType(), 
                                o.GetType().FullName ); 
        }
 
        public static void Main()
        { 
            long longType = 99; 
            Example example= new Example(); 
 
            ShowTypeInfo (example); 
            ShowTypeInfo (longType); 
        }
    }
