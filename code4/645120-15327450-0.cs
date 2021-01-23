    public struct HandCoordinate
    {
         public HandCoordinate(double x, double y, double time)
         {
             this.X = x;
             this.Y = y;
             this.Time= time;
         }
         public readonly double X;
         public readonly double Y;
         public readonly double Time;
    }
    ...
    private static double Velocity(HandCoordinate p1, HandCoordinate p2)
    {
         var time = p2.Time - p1.Time;
         if (time <= 0)
         {
             throw new ArgumentException("Duplicate measurement");
         }
         var dx = p2.X - p1.X;
         var dy = p2.Y - p1.Y;
         var distance = Math.Sqrt(dx*dx + dy*dy);
         // note the possibility for overflow if your times are very close together.
         // You might need to use logarithms for the calculation.
         return distance/time; 
    }
    ...
    
    var points = new SortedList<double,HandCoordinate>();
    points.Add(1.0, new HandCoordinate(1.0, 1.0, 1.0));
    points.Add(1.1, new HandCoordinate(1.0, 2.0, 1.1));
    ..
    var velocities = points.Values
                           .Skip(1)
                           // note: because of the skip i in the following is the offset
                           // from the second element and can be used directly to refer
                           // to the previous element
                           .Select((p,i) => Velocity(points.Values[i],p))
                           .ToList();
