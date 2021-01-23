    public static class DictionaryRangeExtensions
    {
        public IEnumerable<T> FindValuesInRange(this Dictionary<double,T> dictionary, double lowerBound, double upperBound)
        {
             dictionary.Where(kvp=> kvp.Key > lowerBound && kvp.Key < uppoerBound).Select(kvp=>kvp.Value);
        }
    }
