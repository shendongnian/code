        private string[] GetCombined(string[] str)
        {
            var combined = new List<string>();
            var temp = new StringBuilder();
            foreach (var s in str)
            {
                if (s.Length > 1)
                {
                    if (temp.Length > 0)
                    {
                        combined.Add(temp.ToString());
                        temp = new StringBuilder();
                    }
                    combined.Add(s);
                }
                else
                {
                    temp.Append(s);
                }
            }
            if (temp.Length > 0)
            {
                combined.Add(temp.ToString());
                temp = new StringBuilder();
            }
            return combined.ToArray();
        }
