    List<PointLatLng> firstTwoPoints = new List<PointLatLng>();
             firstTwoPoints.Add(poly.Points[0]);
             firstTwoPoints.Add(poly.Points[1]);
    
             GMapPolygon oneLine = new GMapPolygon(firstTwoPoints,"testesddfsdsd"); //Create new polygone from messuring the distance.
             double lengteLocalLine =
                Math.Sqrt(((poly.LocalPoints[1].X - poly.LocalPoints[0].X)*(poly.LocalPoints[1].X - poly.LocalPoints[0].X)) +
                          ((poly.LocalPoints[1].Y - poly.LocalPoints[0].Y)*(poly.LocalPoints[1].Y - poly.LocalPoints[0].Y))); //This calculates the length of the line in LocalPoints. 
             double pointInKm = oneLine.Distance / lengteLocalLine; //This gives me the length of 1 LocalPoint in km.
    
             List<Carthesian> waarden = new List<Carthesian>(); 
    
    //Here we fill the list "waarden" with the points.
    //NOTE: the last value is NOT copied because this is handled in calculation method.
             foreach (GPoint localPoint in poly.LocalPoints)
             {
                waarden.Add(new Carthesian(){X = (localPoint.X * pointInKm), Y = (localPoint.Y * pointInKm)});
             }
    
             MessageBox.Show("" + GetArea(waarden)*1000000);
    
        }
    
    //Method for calculating area
          private double GetArea(IList<Carthesian> points)
          {
             if (points.Count < 3)
             {
                return 0;
             }
             double area = GetDeterminant(points[points.Count - 1].X , points[points.Count - 1].Y, points[0].X, points[0].Y);
    
             for (int i = 1; i < points.Count; i++)
             {
                //Debug.WriteLine("Lng: " + points[i].Lng + "   Lat:" + points[i].Lat);
                area += GetDeterminant(points[i - 1].X, points[i - 1].Y , points[i].X,  points[i].Y);
             }
             return Math.Abs(area / 2);
          }
    
    //Methode for getting the Determinant
    
          private double GetDeterminant(double x1, double y1, double x2, double y2)
          {
             return x1 * y2 - x2 * y1;
          }
    
    
     
    //This class is just to make it nicer to show in code and it also was from previous tries
        class Carthesian
           {
              public double X { get; set; }
              public double Y { get; set; }
              public double Z { get; set; }
           }
