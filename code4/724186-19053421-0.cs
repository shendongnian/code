        public static IEnumerable<string> Scanner(this string tgt, char delim)
        {
            var sb = new StringBuilder();
            foreach (var c in tgt)
            {
                if (c == delim)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
                else sb.Append(c);
            }
        }
