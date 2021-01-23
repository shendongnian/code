        public static void DiffDictionaries<T, U>(
            Dictionary<T, U> dicA,
            Dictionary<T, U> dicB,
            Dictionary<T, U> dicAdd,
            Dictionary<T, U> dicDel)
        {
            // dicDel has entries that are in A, but not in B, 
            // ie they were deleted when moving from A to B
            diffDicSub<T, U>(dicA, dicB, dicDel);
            // dicAdd has entries that are in B, but not in A,
            // ie they were added when moving from A to B
            diffDicSub<T, U>(dicB, dicA, dicAdd);
        }
        private static void diffDicSub<T, U>(
            Dictionary<T, U> dicA,
            Dictionary<T, U> dicB,
            Dictionary<T, U> dicAExceptB)
        {
            // Walk A, and if any of the entries are not
            // in B, add them to the result dictionary.
            foreach (KeyValuePair<T, U> kvp in dicA)
            {
                if (!dicB.Contains(kvp))
                {
                    dicAExceptB[kvp.Key] = kvp.Value;
                }
            }
        }
