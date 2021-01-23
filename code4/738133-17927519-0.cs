    var terms = indexReader.ClosestTerms(field, "dig")
                           .OrderBy(t => t.Item2)
                           .Take(10)
                           .ToArray();
---
    public static class LuceneUtils
    {
        public static IEnumerable<Tuple<string, int>> ClosestTerms(this IndexReader reader, string field, string text)
        {
            return reader.TermsStartingWith(field, text[0].ToString())
                         .Select(x => new Tuple<string, int>(x, LevenshteinDistance(x, text)));
        }
        public static IEnumerable<string> TermsStartingWith(this IndexReader reader, string field, string text)
        {
            using (var tEnum = reader.Terms(new Term(field, text)))
            {
                do
                {
                    var term = tEnum.Term;
                    if (term == null) yield break;
                    if (term.Field != field) yield break;
                    if (!term.Text.StartsWith(text)) yield break;
                    yield return term.Text;
                } while (tEnum.Next());
            }
        }
        //http://www.dotnetperls.com/levenshtein
        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            // Step 1
            if (n == 0) return m;
            if (m == 0) return n;
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++) { }
            for (int j = 0; j <= m; d[0, j] = j++) { }
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
