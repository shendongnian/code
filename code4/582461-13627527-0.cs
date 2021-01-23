            // WARNING WILL NOT ALWAYS RESULT IN THE RIGHT VALUES
            List<Regex> rxs = new List<Regex>(4);
            rxs.Add(new Regex("def"));
            rxs.Add(new Regex("abc"));
            rxs.Add(new Regex("bcd"));
            rxs.Add(new Regex("cde"));
            string target = "abcdef";
            int firstIndex = target.Length;
            string firstMatch = string.Empty;
            foreach (var rx in rxs)
            {
                var match = rx.Match(target, 0, firstIndex);
                if (match.Success)
                {
                    firstIndex = match.Index;
                    firstMatch = match.Value;
                    if (firstIndex == 0) break;
                }
            }
            return firstMatch;
