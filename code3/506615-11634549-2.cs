        // warning, untested
        public String Translate(String s, Dictionary<String, String> mapping)
        {
            String result = "";
            if (RecurTranslate(s, mapping, ref result))
                return result;
            throw new Exception("No translation");
        }
        private bool RecurTranslate(String s, Dictionary<String, String> mapping, ref String result)
        {
            if (s.Length == 0)
                return true;
            for (int prefixLen = s.Length; prefixLen > 0; --prefixLen)
            {
                String prefix = s.Substring(0, prefixLen);
                String trans;
                if (mapping.TryGetValue(prefix, out trans))
                {
                    if (RecurTranslate(s.Substring(prefixLen), mapping, ref result))
                    {
                        result = trans + result;
                        return true;
                    }
                }
                else if (prefixLen == 1)
                {   // this branch allows a character to stand for itself
                    if (RecurTranslate(s.Substring(prefixLen), mapping, ref result))
                    {
                        result = prefix + result;
                        return true;
                    }
                }
            }
            return false;
        }
