            List<string> rxs = new List<string>(4);
            rxs.Add( "def");
            rxs.Add( "abc");
            rxs.Add( "bcd");
            rxs.Add( "cde");
            string target = "abcdef";
            int firstIndex = target.Length;
            string firstMatch = string.Empty;
            foreach (var rx in rxs)
            {
                var match = Regex.Match(target, @"(?<!\A[\w\W]{" + firstIndex + "})" + rx);
                if (match.Success)
                {
                    if (match.Index < firstIndex)
                    {
                        firstIndex = match.Index;
                        firstMatch = match.Value;    
                    }
                    if (firstIndex == 0) break;
                }
            }
