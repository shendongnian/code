    public static string Join(this IEnumerable<string> source, string separator) {
        using(var iter = source.GetEnumerator()) {
            if(!iter.MoveNext()) return "";
            var sb = new StringBuilder(iter.Current);
            while(iter.MoveNext())
                sb.Append(separator).Append(iter.Current);
            return sb.ToString();
        }
    }
