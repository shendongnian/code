    public class User
    {
         public string Name { get; set; }
         public int Age { get; set; }
    
         public override string ToString()
         {
             return this.Name + " is " + this.Age + " years old.";
         }
    }
