    public class LatLonPoint
    {
       public double Latitude { get; set; }
       public double Longitude { get; set; }
       public double X
       {
          get
          {
          .......
          }
       }
       public double Y ....
       public double Z .....
       
       public double DistanceTo(LatLonPoint point)
       {
         double dX = point.X - X;
         double dY = point.Y - Y;
         double dZ = point.Z - Z;
         return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
       }
    }
