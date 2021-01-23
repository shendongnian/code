        private bool RecurTranslate2(String s, Dictionary<String, String> mapping, ref String result)
        {
            if (s.Length == 0)
                return true;
            foreach (var entry in mapping.Where(e => e.Key.Length <= s.Length).OrderByDescending(e => e.Key.Length))
            {
                if (s.Contains(entry.Key))
                {   // split into a before and after
                    int idx = s.IndexOf(entry.Key);
                    String before = s.Substring(0, idx);
                    String after = s.Substring(idx + entry.Key.Length);
                    String bRes = "", aRes = "";
                    if (RecurTranslate2(before, mapping, ref bRes) && RecurTranslate2(after, mapping, ref aRes))
                    {
                        result = aRes + entry.Value + bRes;
                        return true;
                    }
                }
            }
            return false;
        }
