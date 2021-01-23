    public class PersonBase
    {
         private String name;
         public String getName()
         {
              return this.name;
         }
         public void setName(string name)
         {
              this.name = name;
         }
         public bool isNamed(string name)
         {
               return this.name.Equals(name);
         }
    }
    public class Employee : PersonBase
    {
    }
