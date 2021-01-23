    public class VectorEqualityComparer : IEqualityComparer<Vector>
    {
        public bool Equals(Vector x, Vector y)
        {
            //here you implement the equality among vectors you defined in your question
        }
        public int GetHashCode(Vector obj)
        {
            //you can return something like obj.InnerArray.GetHashCode()
        }
    }
