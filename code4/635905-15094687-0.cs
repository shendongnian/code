    class Car : IEquatable<Car>
        {
            public Car(int id, string model)
            {
                ID = id;
                Model = model;
            }
    
            public int ID { get; private set; }
            public string Model { get; private set; }
            
            public bool Equals(Car other)
            {
                return !ReferenceEquals(null, other) && ID == other.ID;
            }
    // This is a must if you like to correctly use your object as a key in dictionary
            public override int GetHashCode()
            {
                return ID.GetHashCode();
            }
        }
