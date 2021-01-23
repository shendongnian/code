     private static List<string> ExtractFromString(string text, string start, string end)
        {            
            List<string> Matched = new List<string>();
            int index_start = 0, index_end=0;
            bool exit = false;
            while(!exit)
            {
                index_start = text.IndexOf(start);
                index_end = text.IndexOf(end);
                if (index_start != -1 && index_end != -1)
                {
                    Matched.Add(text.Substring(index_start + start.Length, index_end - index_start - start.Length));
                    text = text.Substring(index_end + end.Length);
                }
                else
                    exit = true;
            }
            return Matched;
        }
