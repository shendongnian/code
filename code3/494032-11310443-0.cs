    class Vehicle
    {
        public static List<string> canDo = new List<string>() { "go" };   
    }
    class Plane : Vehicle
    {
        public new static List<string> canDo = new List<string>(Vehicle.canDo);
        static Plane()
        {
            canDo.Add("fly");
        }
    }
