        public static string getVersion(Worksheet sht)
        {
            Range range = sht.Range["A1:A10"];
            foreach (Range c in range.Cells)
            {
                if (null == c.Value2) continue;
                string val = c.Value.ToString();
                if (val.Contains("Changes for Version "))
                {
                    int startIndex = ("Changes for Version ").Length;
                    return val.Substring(startIndex, 2).Trim(); 
                }
            }
            return null;
        }
