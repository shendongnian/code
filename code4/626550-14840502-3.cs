    public class PeopleComparer : IEqualityComparer<People>
    {
        public bool Equals(People x, People y)
        {
            return x.Name == y.Name && x.Surname == y.Surname;
        }
        public int int GetHashCode(People obj)
        {
            return (obj.Name.GetHashCode() * 31) + obj.Surname.GetHashCode();
        }
    }
