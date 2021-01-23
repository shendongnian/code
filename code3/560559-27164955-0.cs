        public static string FoldLines(this string value, int max, string newline = "\r\n")
        {
            var lines = value.Split(newline.ToSingleton(), System.StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                var len = line.Length;
                if (len <= max) sb.Append(line).Append(newline);
                else
                {
                    var chars = line.ToArray();
                    var blen = len / max;
                    var rlen = len % max;
                    var b = 0;
                    while (b < blen) sb.Append(chars, (b++) * max, max).AppendFormat("{0} ", newline);
                    if (rlen > 0) sb.Append(chars, blen * max, rlen).AppendFormat("{0}", newline);
                }
            }
            return sb.ToString();
        }
