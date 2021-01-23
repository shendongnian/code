    public static class TupleExtension
    {
        public static IEnumerable SelectByPosition<T>(this IEnumerable<T> lst, int itemNumber) where T : IStructuralEquatable, IStructuralComparable, IComparable
        {
            return lst.Select(t => typeof(T).GetProperty("Item" + Convert.ToString(itemNumber)).GetValue(t)).ToList();
        }
    }
    
