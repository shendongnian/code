    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int parts)
        {
            var list = new List<T>(source);
            int defaultSize = (int)((double)list.Count / (double)parts);
            int offset = list.Count % parts;
            int position = 0;
            for (int i = 0; i < parts; i++)
            {
                int size = defaultSize;
                if (i < offset)
                    size++; // Just add one to the size (it's enough).
                yield return list.GetRange(position, size);
                // Set the new position after creating a part list, so that it always start with position zero on the first yield return above.
                position += size;
            }
        }
    }
    
