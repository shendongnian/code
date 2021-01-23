        public List<string> Split(string src)
        {
            List<string> result = new List<string>();
            int brk = src.IndexOf('{');
            if (brk < 0)
            {
                if (!string.IsNullOrEmpty(src.Trim()))
                    result.Add(src);
                return result;
            }
            string cur = src.Substring(0, brk + 1);
            string remainder = src.Substring(brk + 1);
            int countBrk = 1;
            while (countBrk > 0)
            {
                int idxOpened = remainder.IndexOf('{');
                int idxClosed = remainder.IndexOf('}');
                if (idxOpened >= 0 && idxOpened < idxClosed)
                {
                    countBrk++;
                    cur = cur + remainder.Substring(0, idxOpened + 1);
                    remainder = remainder.Substring(idxOpened + 1);
                }
                else
                {
                    countBrk--;
                    cur = cur + remainder.Substring(0, idxClosed + 1);
                    remainder = remainder.Substring(idxClosed + 1);
                }
            }
            if (!string.IsNullOrEmpty(cur.Trim()))
                result.Add(cur);
            result.AddRange(Split(remainder));
            return result;
        }
