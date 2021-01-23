    public class Car {
        private PrivateWheel wheel;
        public Wheel { get { return wheel; } }
        public abstract class Wheel
        {
        }             
        
        private class PrivateWheel : Wheel
        {
            public int WheelSize { get; set; }
        }
        
        public static Wheel CreateWheel()
        {
            return new PrivateWheel();
        }
    }
