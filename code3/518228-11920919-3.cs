    public class Cube
    {
       public Point Center {get ; set;}
       public Cube Clone() {
           var cube = this.MemberwiseClone();
           cube.Center = this.Center.Clone();
           return cube;
       }
   }
