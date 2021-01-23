    public class MyClass
    {
       public struct Coordinate
       {
           public double Lat;
           public doubel Lon;
       }
       [DataMember(Name = "location")]
       private double[] _Location { get; set; }
       public Coordinate Location
       {
           get
           {
               return new Coordinate { Lat = _Location[0], Lon = _Location[1]};
           }
           set
           {
               double[0] = value.Lat;
               double[1] = value.Lon;
       }
    }
