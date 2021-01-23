    public class Car : IEquatable<Car>, ICloneable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Equals(Car other)
        {
            return other.Make == this.Make &&
                   other.Model == this.Model;
        }
        public object Clone()
        {
            return new Car { Make = this.Make, Model = this.Model };
        }
    }
