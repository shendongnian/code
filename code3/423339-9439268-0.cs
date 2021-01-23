    public struct PolarCoordinates
    {
      public double Rho;
      public double Theta;
    }
    
    public struct CartesianCoordinates
    {
      public double X;
      public double Y;
    }
    
    public Complex(PolarCoordinates pc);
    public Complex(CartesianCoordinates cc);
