    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IList<T> source, int n)
    {
        return Combinations(source.Count, n)
            .Select(combination => combination.Select(i => source[i]));
    }
    public static IEnumerable<IEnumerable<int>> Combinations(int n, int p)
    {
        //this is logically treated as a stack except that when enumerated it's enumerated as the 
        //reverse of a stack, which is desirable.  There is no efficient way to get the reverse iterator
        //of System.Collections.Stack so easily.  All mutations are to the end of the list.
        var stack = Enumerable.Range(0, p).ToList();
        while (stack[stack.Count - 1] < n)
        {
            //the ToList can be removed if previous sub-sequences won't be iterated 
            //after the outer sequence moves to the next item.
            yield return stack.ToList();
            int lastValue = stack.Pop();
            while (stack.Any() && lastValue + 1 > n - (p - stack.Count))
            {
                lastValue = stack.Pop();
            }
            while (stack.Count < p)
            {
                lastValue += 1;
                stack.Add(lastValue);
            }
        }
    }
    //simple helper method to get & remove last item from a list
    public static T Pop<T>(this List<T> list)
    {
        T output = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return output;
    }
