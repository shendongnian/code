     public class MyObject
     {
        public int X, Y, Z, M;
        public override int GetHashCode()
        {
              return X*10000 + Y*100 + Z*10 + M;
        }
        public override bool Equals(object obj)
        {
            return (obj.GetHashCode() == this.GetHashCode());
        }
    }
