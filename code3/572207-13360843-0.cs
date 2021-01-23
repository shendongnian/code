    public class MyOwnTypeOfAngle
    {
 
        public MyOwnTypeOfAngle(Angle input)
        {
            this.Radians = input.Radians;
            this.Degrees = input.Degrees;
        }
  
        public double Radians { get; set; }
        public double Degrees { get; set; }
    }
