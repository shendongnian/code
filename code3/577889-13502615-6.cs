    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
    {
        int total = list.Count();
        int defaultSize = (int)((double)total / (double)parts);
        int offset = total % parts;
        int position = 0;
                
        for (int i = 0; i < parts; i++)
        {
            int size = defaultSize;
            if (i < offset)
                size++;
    
            yield return list.Skip(position).Take(size);
    
            position += size;
        }
    }
    
