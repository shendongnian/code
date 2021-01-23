        /// <summary>
        /// Gets a list of words in the text. A word is any string sequence between two separators.
        /// No word is added if separators are consecutive (would mean zero length words).
        /// </summary>
        public static List<string> GetWords(this string Text, char WordSeparator)
        {
            List<int> SeparatorIndices = Text.IndicesOf(WordSeparator.ToString(), true);
            int LastIndexNext = 0;
            List<string> Result = new List<string>();
            foreach (int index in SeparatorIndices)
            {
                int WordLen = index - LastIndexNext;
                if (WordLen > 0)
                {
                    Result.Add(Text.Substring(LastIndexNext, WordLen));
                }
                LastIndexNext = index + 1;
            }
            return Result;
        }
        /// <summary>
        /// returns all indices of the occurrences of a passed string in this string.
        /// </summary>
        public static List<int> IndicesOf(this string Text, string ToFind, bool IgnoreCase)
        {
            int Index = -1;
            List<int> Result = new List<int>();
            string T, F;
            if (IgnoreCase)
            {
                T = Text.ToUpperInvariant();
                F = ToFind.ToUpperInvariant();
            }
            else
            {
                T = Text;
                F = ToFind;
            }
            do
            {
                Index = T.IndexOf(F, Index + 1);
                Result.Add(Index);
            }
            while (Index != -1);
            Result.RemoveAt(Result.Count - 1);
            return Result;
        }
        /// <summary>
        /// Implemented - returns all the strings in uppercase invariant.
        /// </summary>
        public static string[] ToUpperAll(this string[] Strings)
        {
            string[] Result = new string[Strings.Length];
            Strings.ForEachIndex(i => Result[i] = Strings[i].ToUpperInvariant());
            return Result;
        }
        
