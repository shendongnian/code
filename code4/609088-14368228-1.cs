    static public class Extensions
    {
        static public int GetFrequencyCount<K>(this Dictionary<K, int> counts, K value)
        {
            int result;
            if (counts.TryGetValue(value, out result))
            {
                return result;
            }
            else return 0;
        }
    }
