    static class Ext
    {
        public static GroupResult ApplyCriteria(this IEnumerable<string> source, string criteria)
        {
            var elements = source.ToConcatenedString();
    
            return new GroupResult { Criteria = criteria, Count = elements.CountOcurrences(criteria) };
        }
    
        public static int CountOcurrences(this string source, string phrase)
        {
            return source
                .Select((c, i) => source.Substring(i))
                .Count(sub => sub.StartsWith(phrase));
        }
    
        public static string ToConcatenedString<TSource>(this IEnumerable<TSource> source)
        {
            var sb = new StringBuilder();
    
            foreach (var value in source)
            {
                sb.Append(value);
            }
    
            return sb.ToString();
        }
    }
