    public interface IHaveNameAndAge
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    
    public class ObjectA : IHaveNameAndAge
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int RollNo { get; set; }
        int Ranl { get; set; }
    }
    
    public class ObjectB : IHaveNameAndAge
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public class MyEqualityComparer : IEqualityComparer<IHaveNameAndAge>
    {
        public bool Equals(IHaveNameAndAge x, IHaveNameAndAge y)
        {
            if (ReferenceEquals(x, y))
                return true; 
            return x.Age == y.Age && String.Equals(x.Name, y.Name, StringComparison.Ordinal);
        }
    
        public int GetHashCode(IHaveNameAndAge obj)
        {
            return obj.Age.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
