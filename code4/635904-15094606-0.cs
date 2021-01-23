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
                return this.ID == other.ID;
            }
        }
