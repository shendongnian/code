    public static string Join<T>(string separator, IEnumerable<T> values)
    {
    
        if (values == null)
        {
            throw new ArgumentNullException("values");
        }
        if (separator == null)
        {
            separator = Empty;
        }
        using (IEnumerator<T> enumerator = values.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                return Empty;
            }
            StringBuilder sb = StringBuilderCache.Acquire(0x10);
            if (enumerator.Current != null)
            {
                string str = enumerator.Current.ToString();
                if (str != null)
                {
                    sb.Append(str);
                }
            }
            while (enumerator.MoveNext())
            {
                sb.Append(separator);
                if (enumerator.Current != null)
                {
                    string str2 = enumerator.Current.ToString();
                    if (str2 != null)
                    {
                        sb.Append(str2);
                    }
                }
            }
            return StringBuilderCache.GetStringAndRelease(sb);
        }
    }
