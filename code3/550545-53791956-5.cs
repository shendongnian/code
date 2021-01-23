    public sealed class Car : IEquatable<Car>
    {
        public double Price { get; }
        public List<Components> Components { get; }
   
        ...
        public override bool Equals(object obj)
            => obj is Car other && Equals(other);
        public bool Equals(Car other)
            => Price == other.Price
                && Components.SetwiseEquivalentTo(other.Components);
        public override int GetHashCode()
            => Components.Aggregate(
                Price.GetHashCode(),
                (code, next) => code ^ next.GetHashCode()); // Bitwise XOR
    }
