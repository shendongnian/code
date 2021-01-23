    public class FotoEqualityComparer : IEqualityComparer<Foto>
    {
        public bool Equals(Foto x, Foto y)
        {
             return x.smallurl.Equals(y.smallurl);   
        }
        public int GetHashCode(Foto foto)
        {
             return foto.smallurl.GetHashCode();
        }
    }
