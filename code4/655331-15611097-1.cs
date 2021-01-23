            string str = "S AAA BBBBBBB CC DDDDDD V";
            var words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            List<string> result = new List<string>();
            for (int i = 0; i < words.Length; ++i)
            {
                if (sb.Length == 0)
                {
                    sb.Append(words[i]);
                }
                else if (sb.Length + words[i].Length < 7)
                {
                    sb.Append(' ');
                    sb.Append(words[i]);
                }
                else
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                    sb.Append(words[i]);
                }
            }
            if (sb.Length > 0)
            {
                result.Add(sb.ToString());
            }
