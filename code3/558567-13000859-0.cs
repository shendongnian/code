    class Program
        {
            //declare constant
            const double ANGLES_FROM_RADIANS = 57.295779513082323;
    
            static void shdg()
            {
                //declare vairiables
                double xc = 0.0;
                double yc = 0.0;
                double radius = 0.0;
                double theta = 0.0;
            }
    
            //method prologue
            static void GetUserInput(ref double xc, ref double yc)
            {
                xc = 0;
                yc = 0;
                while (xc == 0)
                {
                    Console.WriteLine("Please enter a possitive, non-zero value for the  x-ccordinate   of a point.");
                    xc = int.Parse(Console.ReadLine());
                    if (xc <= 0)
                    {
                        Console.WriteLine("Error, x must be greater than zero.");
                    }
                }
                Console.WriteLine("Please enter a possitive value for the y-coordinate of a point.");
                yc = int.Parse(Console.ReadLine());
    
                Console.WriteLine("Your Coordinates are ({0},{1})", xc, yc);
            }
    
            //method prologue
            static double CalcCoords(double xc, double yc, ref double radius, ref double theta)
            {
                {
                    radius = Math.Sqrt((xc * yc) + (xc * yc));
                    return radius;
                }
                {
                    theta = Math.Atan(yc / xc) * ANGLES_FROM_RADIANS;
                    return theta;
                }
            }
    
            //method prologue
            static void Output(double radius, double theta)
            {
                Console.WriteLine("For your polar coordinates:");
                Console.WriteLine("Distance from the origin: {0:f}", radius);
                Console.WriteLine("The angle (in degrees) from the x-axis is: {0:f3}", theta);
            }
        }//End class Program
