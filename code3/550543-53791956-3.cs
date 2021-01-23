    public sealed class Car : IEquatable<Car>
    {
        public double Price { get; }
        public List<Components> Components { get; }
   
        ...
        public bool Equals(Car other)
            => Price == other.Price
                && Components.SetwiseEquivalentTo(other.Components);
    }
