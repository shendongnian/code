     public static class ListExtensions 
     {
        public static void RemoveAllIndices<T>(this List<T> list, IEnumerable<int> indices)
        {
            var indicesOrdered = indices.Distinct().ToArray();
            if(indicesOrdered.Length == 0)
                return;
            Array.Sort(indicesOrdered);
            if (indicesOrdered[0] < 0 || indicesOrdered[indicesOrdered.Length - 1] >= list.Count)
                throw new ArgumentOutOfRangeException();
            int indexToRemove = 0;
            int newIdx = 0;
            for (int originalIdx = 0; originalIdx < list.Count; originalIdx++)
            {
                if(indexToRemove < indicesOrdered.Length && indicesOrdered[indexToRemove] == originalIdx)
                {
                    indexToRemove++;
                }
                else
                {
                    list[newIdx++] = list[originalIdx];
                }
            }
            list.RemoveRange(newIdx, list.Count - newIdx);
        }
    }
