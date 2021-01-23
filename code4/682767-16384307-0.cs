    public class CharacterComparer : IEqualityComparer<Character>
    {
        public bool Equals(Character x, Character y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            // Ignore case and culture
            return string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
        public int GetHashCode(Character obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.Name))
            {
                return 0;
            }
            return obj.Name.GetHashCode();
        }
    }
