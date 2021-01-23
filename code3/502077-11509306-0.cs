    public class MyClass
    {
           [DataMember(Name = "location")]
           public double[] Location { get; set; }
    
           public Coordinate Coordinate
           {
                get
                {
                      if(Location.Lenght > 2)
                      {
                            return new Coordinate() { Lat = Location[0], Lang = Location[1] };
                      }
    
                      return null;
                }
           }
    
    }
    
    public class Coordinate
    {
          public double Lat { get; set;}
          public double Lang { get; set;}
    }
