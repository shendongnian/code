    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public string BaseCode { get; set; }
        public List<Location> Locations { get; set; }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;
            bool samePerson = Name == other.Name;
            // This is simpler because of IEquatable<Location>
            bool sameLocations = !Locations.Except(other.Locations).Any();
            return samePerson && sameLocations;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    public class Location : IEquatable<Location>
    {
        public string Name { get; set; }
        public bool Equals(Location other)
        {
            if (other == null)
                return false;
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
