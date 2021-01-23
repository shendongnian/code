               string s = "red house";   
                foreach (char c in s)
                {
                    if (s.IndexOf(c) != s.LastIndexOf(c))
                    {
                        label1.Text += c.ToString();
                    }
                    s.Replace(c.ToString(), string.Empty);
                }
