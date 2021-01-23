    class FotoEqualityComparer : IEqualityComparer<Foto>
    {
        public bool Equals(Foto f1, Foto f2)
        {
            return f1.smallurl == f2.smallurl;
        }
        public int GetHashCode(Foto f)
        {
             return f.smallurl.GetHashCode();
        }
    }
    @foreach (Foto f in fotos.Distinct(new FotoEqualityComparer() )
