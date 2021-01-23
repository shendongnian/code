    public class User : AbstractEntity<int>
    {
        public string Name { get; set; }
        public List<Car> OtherCars { get; set; }
        public Car MainCar { get; set; }
        public bool Equals(Car other)
        {
            if (this.Id == other.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Car : AbstractEntity<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Equals(Car other)
        {
            if (this.Id == other.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
