       public static void PrintAuthorInfo(Type t) 
       {
          Console.WriteLine("Author information for {0}", t);
          Attribute[] attrs = Attribute.GetCustomAttributes(t);
          foreach(Attribute attr in attrs) 
          {
             if (attr is Author) 
             {
                Author a = (Author)attr;
                Console.WriteLine("   {0}, version {1:f}",
    a.GetName(), a.version);
             }
          }
       }
