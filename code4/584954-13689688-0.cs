    class MyType1
    {
      public MyType1(int id, string name) {Id = id; Name = name;}
      public int Id {get; private set;}
      public string Name {get; private set;}
    }
    
    
    internal class MyType2
    {
        public MyType2(int id, string name)
        {
            Id = id;
            Name = name;
        }
    
        public int Id { get; private set; }
        public string Name { get; private set; }
    
        bool Equals(MyType2 other)
        {
            return Id == other.Id && string.Equals(Name, other.Name);
        }
    
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyType2) obj);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                return (Id*397) ^ Name.GetHashCode();
            }
        }
    }
    
    var d1 = new Dictionary<MyType1, int>();
    d1[new MyType1(1, "1")] = 1;
    d1[new MyType1(1, "1")]++; // will throw withKeyNotFoundException
    
    var d2 = new Dictionary<MyType2, int>();
    d1[new MyType2(1, "1")] = 1;
    d1[new MyType2(1, "1")]++; // Ok, we'll find appropriate record in dictionary
