    public static List<int> FindAllIndexOf<T>(List<T> values, List<T> matches)
        {
            // Initialize list
            List<int> index = new List<int>();
            // For each value in matches get the index and add to the list with indexes
            foreach (var match in matches)
            {
                // Find matches 
                index.AddRange(values.Select((b, i) => Equals(b, match) ? i : -1).Where(i => i != -1).ToList());
            }
            return index;
        }
