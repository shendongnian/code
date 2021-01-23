    //Extension method to find a subset of sequential consecutive elements with at least the specified count of members.
    //Comparisions are based on the field value in the selector.
    //Quick implementation for purposes of the example...
    //Ignores error and bounds checking for purposes of example.  
    //Also assumes we are searching for descending consecutive sequential values.
    public static IEnumerable<T> FindConsecutiveSequence<T>(this IEnumerable<T> sequence, Func<T, int> selector, int count)
    {
        int start = 0;
        int end = 1;
        T prevElement = sequence.First();
        foreach (T element in sequence.Skip(1))
        {
            if (selector(element) + 1 == selector(prevElement))
            {
                end++;
                if (end - start == count)
                {
                    return sequence.Skip(start).Take(count);
                }
            }
            else
            {
                start = end;
                end++;
            }
            prevElement = element;
        }
        return sequence.Take(0);
    }
    //Compares cards based on value alone, not suit.
    //Again, ignores validation for purposes of quick example.
    public class CardValueComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return x.Val == y.Val ? true : false;
        }
        public int GetHashCode(Card c)
        {
            return c.Val.GetHashCode();
        }
    }
