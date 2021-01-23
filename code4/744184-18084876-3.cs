    public class AnotherRobotType
    {
        public string Model {get;set;} // public property
        private int _make; // private property
        public AnotherRobotType() {
        }
    
        /* these are methods that set the object's internal state
        this is a contrived example, b/c in reality you would use a auto-property (like Model) for this */
        public int getMake() { return _make; }
        public void setMake(int val) { _make = val; } 
    }
    
    public static class Program
    {
        public static void Main(string[] args)
        {
           // setting object properties from another class
           var robot = new AnotherRobotType();
           robot.Model = "bender";
           robot.setMake(1000);
        }
    }
