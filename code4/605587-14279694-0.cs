    public class Paint {
    
      public string Name { get; private set; }
    
      public Paint(string name) {
        switch (name) {
          case "Red":
          case "Green":
          case "Blue":
            Name = name;
            break;
          default:
            throw new ArgumentException("Illegal paint name '" + name + "'.");
        }
      }
    
    }
