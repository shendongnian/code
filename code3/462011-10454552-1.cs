    public class Person : IEquatable<Person>
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public Address Address { get; set; }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Person);
        }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;
            return this.Age.Equals(other.Age) &&
                (
                    object.ReferenceEquals(this.FirstName, other.FirstName) ||
                    this.FirstName != null &&
                    this.FirstName.Equals(other.FirstName)
                ) &&
                (
                    object.ReferenceEquals(this.Address, other.Address) ||
                    this.Address != null &&
                    this.Address.Equals(other.Address)
                );
        }
    }
    
    public class Address : IEquatable<Address>
    {
        public int HouseNo { get; set; }
        public string Street { get; set; }
        public City City { get; set; }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Address);
        }
        public bool Equals(Address other)
        {
            if (other == null)
                return false;
            return this.HouseNo.Equals(other.HouseNo) &&
                (
                    object.ReferenceEquals(this.Street, other.Street) ||
                    this.Street != null &&
                    this.Street.Equals(other.Street)
                ) &&
                (
                    object.ReferenceEquals(this.City, other.City) ||
                    this.City != null &&
                    this.City.Equals(other.City)
                );
        }
    }
    public class City : IEquatable<City>
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as City);
        }
        public bool Equals(City other)
        {
            if (other == null)
                return false;
            return
                object.ReferenceEquals(this.Name, other.Name) ||
                this.Name != null &&
                this.Name.Equals(other.Name);
        }
    }
