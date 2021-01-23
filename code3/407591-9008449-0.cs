    public class Car {
        public int Speed { get; set; }
        public static main(string[] args) {
            Car a = new Car();
            Car b = new Car();
            
            // This is fine:
            var aSpeed = a.Speed;
            // This doesn't make sense (and doesn't compile)
            // Are we talking about a's speed?  b's speed?  Some other car's speed?
            var someSpeed = Speed;
        }
    }
