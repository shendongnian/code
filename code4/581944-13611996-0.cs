    public class DictionaryEqualityComparer<TKey,TValue> : IEqualityComparer<Dictionary<TKey,TValue>>
    {
        public bool Equals( Dictionary<TKey , TValue> x , Dictionary<TKey , TValue> y )
        {
            bool unequal =  x.Count != y.Count
                         || x.Except( y ).Any() // this is probably redundant
                         || y.Except( x ).Any() // but my caffiene titration is off this AM
                         ;
            return !unequal ; 
        }
        public int GetHashCode( Dictionary<TKey , TValue> obj )
        {
            return obj.GetHashCode() ;
        }
