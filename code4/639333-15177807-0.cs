    using System;
    using System.Collections.Generic;
    using System.Globalization;
    /// <summary>
    ///     Contains approximate string matching
    /// </summary>
    internal static class LevenshteinDistance
    {
        /// <summary>
        ///     Compute the distance between two strings using text elements.
        /// </summary>
        public static int ComputeByTextElements(string s, string t) {
            string[] strA = GetTextElements(s),
                     strB = GetTextElements(t);
            int n = strA.Length;
            int m = strB.Length;
            var d = new int[n + 1,m + 1];
            // Step 1
            if (n == 0) {
                return m;
            }
            if (m == 0) {
                return n;
            }
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++) {}
            for (int j = 0; j <= m; d[0, j] = j++) {}
            // Step 3
            for (int i = 1; i <= n; i++) {
                //Step 4
                for (int j = 1; j <= m; j++) {
                    // Step 5
                    int cost = (strB[j - 1] == strA[i - 1]) ? 0 : 1;
                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
        private static string[] GetTextElements(string str) {
            if (string.IsNullOrEmpty(str)) {
                return new string[] {};
            }
            var result = new List<string>();
            var enumerator = StringInfo.GetTextElementEnumerator(str);
            while (enumerator.MoveNext()) {
                result.Add(enumerator.Current.ToString());
            }
            return result.ToArray();
        }
    }
