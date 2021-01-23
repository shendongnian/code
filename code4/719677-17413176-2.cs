    namespace System
    {
        public static class StringExtensions
        {
            public static Dictionary<string, string> SplitQueryString(this string queryString)
            {
                var splitVals = queryString.Split('/');
                var vals = new Dictionary<string, string>();
                for (int i = 2; i <= splitVals.Count; i++)
                {
                    vals.Add(string.Format("param{0}", i), vals[i]);
                }
                return vals;
            }
        }
    }
