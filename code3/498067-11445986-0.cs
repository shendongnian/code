     public static string RemoveIncompleteTags(string source, string tag)
        {
            source = source.Replace("  ", " ");
            source = source.Replace("/n", string.Empty).Replace("/r", string.Empty).Replace("/t", string.Empty);
            source = source.Replace("<" + tag + "></" + tag + ">", string.Empty);
            source = source.Replace("<" + tag + "> </" + tag + ">", string.Empty);
            source = source.Replace("<" + tag + ">  </" + tag + ">", string.Empty);
            Dictionary<int, string> oDict = new Dictionary<int, string>();
            string[] souceList;
            Dictionary<int, string> final = new Dictionary<int, string>();
            bool opening = false;
            bool operate = false;
            source = source.Replace("  ", " ");
            source = source.Replace(">", "> ").Replace("<", " <");
            source = source.Replace(" >", ">").Replace("< ", "<");
            source = source.Replace("  ", " ").Replace("  ", " ");
            souceList = source.Split(' ');
            for (int i = 0; i < souceList.Length; i++)
            {
                string word = souceList[i];
                if (word.ToLower() == "<" + tag.ToLower() + ">")
                {
                    opening = true;
                    operate = true;
                }
                else if (word.ToLower() == "</" + tag.ToLower() + ">")
                {
                    opening = false;
                    operate = true;
                }
                if (operate)
                {
                    if (opening)
                    {
                        oDict.Add(i, word);
                        final.Add(i, word);
                    }
                    else
                    {
                        if (oDict.Count != 0)
                        {
                            oDict.Remove(oDict.Last().Key);//.ToList().RemoveAt(oDict.Count - 1);
                            final.Add(i, word);
                        }
                        else
                        {
                            // need not to add to the output string 
                            // code if you want to log
                        }
                    }
                    operate = false;
                    opening = false;
                }
                else
                {
                    final.Add(i, word);
                }
            }
            if (final.Count > 0)
            {
                if (oDict.Count > 0)
                {
                    foreach (var key in oDict.Keys)
                    {
                        final.Remove(key);
                    }
                }
                StringBuilder fText = new StringBuilder();
                final.ToList().ForEach(wd =>
                    {
                        if (wd.Value.Trim().Length > 0)
                            fText.Append(wd.Value.Trim() + " ");
                    });
                return fText.ToString().Trim();
            }
            else
            {
                return string.Empty;
            }
        }
