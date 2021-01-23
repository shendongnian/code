    public class Wrapper<T>
    {
        public T Value { get; set; }
    }
    public static IEnumerable<T> Merge<T>(IEnumerable<T> first, IEnumerable<T> second, IComparer<T> comparer = null)
    {
        comparer = comparer ?? Comparer<T>.Default;
    
        using (var secondIterator = second.GetEnumerator())
        {
            Wrapper<T> secondItem = null; //when the wrapper is null there are no more items in the second sequence
    
            if (secondIterator.MoveNext())
                secondItem = new Wrapper<T>() { Value = secondIterator.Current };
            foreach (var firstItem in first)
            {
                if (secondItem != null)
                {
                    while (comparer.Compare(firstItem, secondItem.Value) > 0)
                    {
                        yield return secondItem.Value;
                        if (secondIterator.MoveNext())
                            secondItem.Value = secondIterator.Current;
                        else
                            secondItem = null;
                    }
                }
                yield return firstItem;
    
                yield return secondItem.Value;
                while (secondIterator.MoveNext())
                    yield return secondIterator.Current;
            }
        }
    }
