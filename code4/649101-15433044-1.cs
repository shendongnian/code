    public static IEnumerable<byte> Escape(this IEnumerable<byte> source)
    {
        if (source == null)     
            throw new ArgumentNullException("source");
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                byte current = enumerator.Current;
                if (current != 0xF8)
                {
                    yield return current;
                    continue;
                }
                if (!enumerator.MoveNext())
                    yield return current;
                byte next = enumerator.Current;
                switch (next)
                {
                    case 0x00: yield return 0xF8; break;
                    case 0x01: yield return 0xFB; break;
                    case 0x02: yield return 0xFD; break;
                    case 0x03: yield return 0xFE; break;
                    default:
                        yield return current;
                        yield return next;
                        break;
                }
            }
        }
    }
