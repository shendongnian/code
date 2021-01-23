       dynamic obj = GetAnonymousType();
       Console.WriteLine(obj.Name);
       Console.WriteLine(obj.LastName);
       Console.WriteLine(obj.Age); 
       public static dynamic GetAnonymousType()
       {
           return new { Name = "John", LastName = "Smith", Age=42};
       }
