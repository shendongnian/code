    public class Service: Entity
    {
      public string Name { get; set; }
      public override string ToString(){
         return Name;
      }
    }
    public class City: Entity
    {
      public string Name { get; set; } // Max 50 chars
      public override string ToString(){
         return Name;
      }
    }
