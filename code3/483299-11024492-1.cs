    public abstract class Vector
    {
        protected abstract Vector Add(Vector otherVector);
    
        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }
    }
    
    public class SubVector : Vector
    {
        protected override Vector Add(Vector otherVector)
        {
            //do some SubVector addition
        }
    }
