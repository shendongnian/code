    public class Car {
        public abstract class Wheel
        {
            //I want this to be only accessible within Car and Wheel
            private int wheelSize;
        }             
        
        private class PrivateWheel : Wheel
        {
            public int LocalProp { get; set; }
        }
        
        public static Wheel CreateWheel()
        {
            return new PrivateWheel();
        }
    }
