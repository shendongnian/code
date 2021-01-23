	public static string Join(string separator, IEnumerable<string> values)
	{
	    using (IEnumerator<string> enumerator = values.GetEnumerator())
	    {
	        if (!enumerator.MoveNext())
	        {
	            return Empty;
	        }
	        StringBuilder sb = StringBuilderCache.Acquire(0x10);
	        if (enumerator.Current != null)
	        {
	            sb.Append(enumerator.Current);
	        }
	        while (enumerator.MoveNext())
	        {
	            sb.Append(separator);
	            if (enumerator.Current != null)
	            {
	                sb.Append(enumerator.Current);
	            }
	        }
	        return StringBuilderCache.GetStringAndRelease(sb);
	    }
	}
