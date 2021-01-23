    public class Horse : Animal {
       public int horseid { get { return id; } set { id = value; } }
       public Horse() : base() {}
       public Horse(DataRow dr) : base(dr) {}
    }
