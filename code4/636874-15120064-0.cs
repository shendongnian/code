    public class Car
    {
        public Car(int id, string make, string model, int year)
        {
            ID = id;
            Make = make;
            Model = model;
            Year = year;
        }
        public int ID { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public void Accelerate() { }
        public void Decelerate() { }
    }
