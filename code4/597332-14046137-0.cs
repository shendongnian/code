    public static IEnumerable<U> Except<R, S, T, U>(this IEnumerable<R> mainList, 
                                                    IEnumerable<S> toBeSubtractedList,
                                                    Func<R, T> mainListFunction, 
                                                    Func<S, T> toBeSubtractedListFunction,
                                                    Func<R, U> resultSelector)
    {
        return EnumerateToCheck(mainList, toBeSubtractedList, mainListFunction, 
                                toBeSubtractedListFunction, resultSelector, false);
    }
    static IEnumerable<U> EnumerateToCheck<R, S, T, U>(IEnumerable<R> mainList, 
                                                       IEnumerable<S> secondaryList,
                                                       Func<R, T> mainListFunction, 
                                                       Func<S, T> secondaryListFunction,
                                                       Func<R, U> resultSelector,
                                                       bool ifFound)
    {
        foreach (var r in mainList)
        {
            bool found = false;
            foreach (var s in secondaryList)
            {
                if (object.Equals(mainListFunction(r), secondaryListFunction(s)))
                {
                    found = true;
                    break;
                }
            }
            if (found == ifFound)
                yield return resultSelector(r);
        }
        //or may be just
        //return mainList.Where(r => secondaryList.Any(s => object.Equals(mainListFunction(r), secondaryListFunction(s))) == ifFound)
        //               .Select(r => resultSelector(r));
        //but I like the verbose way.. easier to debug..
    }
    public static IEnumerable<U> Intersect<R, S, T, U>(this IEnumerable<R> mainList, 
                                                       IEnumerable<S> toIntersectList,
                                                       Func<R, T> mainListFunction,
                                                       Func<S, T> toIntersectListFunction,
                                                       Func<R, U> resultSelector)
    {
        return EnumerateToCheck(mainList, toIntersectList, mainListFunction, 
                                toIntersectListFunction, resultSelector, true);
    }
