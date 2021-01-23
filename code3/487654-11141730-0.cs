    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ClassLibrary1
    {
       public class Person
       {
          public string Name { get; set; }
       }
    
       public static class PersonExtensions
       {
          public static void Rename(this Person person, String newName)
          {
             person.Name = newName;
          }
       }
    }
