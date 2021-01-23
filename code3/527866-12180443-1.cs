    public class MyOwnType : IComparable
    {
        public int Id { get; set; }
        public MyOwnType(int id)
        {
            this.Id = id;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            MyOwnType other = obj as MyOwnType;
            if (other != null)
                return this.Id.CompareTo(other.Id);
            else
                throw new ArgumentException("Object is not a MyOwnType");
        }
    }
