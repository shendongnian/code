    public class Vehicle
    {
        public static Vehicle Car = new Vehicle("Car");
        public static Vehicle MotorBike = new Vehicle("MotorBike");
        public static Vehicle PeopleMover = new Vehicle("PeopleMover");
    
        private Vehicle(string name)
        {
            this.name = name
        }
        private string name;
    }
