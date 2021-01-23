        public List<LinkItem> getListOfLinksFromPage(string webpage)
        {
            WebClient w = new WebClient();
            List<LinkItem> list = new List<LinkItem>();
            try
            {
                string s = w.DownloadString(webpage);
                foreach (LinkItem i in LinkFinder.Find(s))
                {
                    //Debug.WriteLine(i);
                    //richTextBox1.AppendText(i.ToString() + "\n");
                    list.Add(i);
                }
                listTest = list;
                return list;
            }
            catch (Exception e)
            {
                return list;
            }
        }
        public struct LinkItem
        {
            public string Href;
            public string Text;
            public override string ToString()
            {
                return Href;
            }
        }
        static class LinkFinder
        {
            public static List<LinkItem> Find(string file)
            {
                List<LinkItem> list = new List<LinkItem>();
                // 1.
                // Find all matches in file.
                MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);
                // 2.
                // Loop over each match.
                foreach (Match m in m1)
                {
                    string value = m.Groups[1].Value;
                    LinkItem i = new LinkItem();
                    // 3.
                    // Get href attribute.
                    Match m2 = Regex.Match(value, @"href=\""(.*?)\""",
                    RegexOptions.Singleline);
                    if (m2.Success)
                    {
                        i.Href = m2.Groups[1].Value;
                    }
                    // 4.
                    // Remove inner tags from text.
                    string t = Regex.Replace(value, @"\s*<.*?>\s*", "",
                    RegexOptions.Singleline);
                    i.Text = t;
                    list.Add(i);
                }
                return list;
            }
        }
