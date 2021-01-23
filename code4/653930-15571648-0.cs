    public static class Extensions
    {
        public static TList BinaryFind<TList>(this IList<TList> list, Func<TList, int> comparer)
        {
            if (!list.Any())
                return default(TList);
            int pivot = list.Count()/2;
            TList pivotVal = list[pivot];
            int conditionResult = condition(pivotVal);
            if (conditionResult == 0) 
                return pivotVal;
            else
            {
                if (conditionResult < 0) 
                    return BinaryFind<TList, TSearchArg>(list.Take(pivot).ToList(), condition);
                else
                    return BinaryFind<TList, TSearchArg>(list.Skip(pivot).ToList(), condition);
            }
        }
    }
