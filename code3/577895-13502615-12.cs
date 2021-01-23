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
                size++; // Just add one to the size (it's enough).
    
            yield return list.Skip(position).Take(size);
    
            // Set the new position after creating a part list, so that it always start with position zero on the first yield return above.
            position += size;
        }
    }
    
