    public static class Exts
    {
        public static SortedList<TK, TV> ToSortedList<TEl, TK, TV>(
            this IEnumerable<TEl> elements,
            Func<TEl, TK> keySelector, 
            Func<TEl, TV> valueSelector)
        {
            if(elements == null || keySelector == null || valueSelector == null)
                throw new ArgumentNullException("An argument of ToSortedList is null");
            var dict = new SortedList<TK, TV>();
            foreach (var el in elements)
                dict.Add(keySelector(el), valueSelector(el));
            return dict;
        }
    }
