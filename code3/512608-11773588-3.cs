        public static string InsertStringRepeatedly(string source, int skip, int insertEvery, string toInsert)
        {
            var sb = new StringBuilder();
            using (var sr = new StringReader(source))
            {
                var buffer = new char[Math.Max(skip, insertEvery)];
                var read = sr.Read(buffer, 0, skip);
                sb.Append(buffer, 0, read);
                while (sr.Peek() > 0)
                {
                    sb.Append(toInsert);
                    read = sr.Read(buffer, 0, insertEvery);
                    sb.Append(buffer, 0, read);
                }
            }
            return sb.ToString();
        }
