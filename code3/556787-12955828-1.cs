    public class MyObjSimilarity : EqualityComparer<myObj>
    {
        public override bool Equals(myObj a, myObj b)
        {
            if (obj.Data1 == this.Data1 && obj.Data2 == this.Data2)
            {
                return true;
            }
            
            return false;
        }
        public override int GetHashCode(myObj o)
        {
            int hash = 17;
            hash = hash * 23 + o.Data1.GetHashCode();
            hash = hash * 23 + o.Data2.GetHashCode();
            return hash;
        }
    }
