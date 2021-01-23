    public static string ClearHtmlTags(string html)
            {
                if (string.IsNullOrWhiteSpace(html)) 
                    return html;
    
                html = html.Trim();
                string[] hs = html.Split("<>".ToArray());
                bool skip = false;
                bool skipTag = false;
    
                StringBuilder sb = new StringBuilder();
                foreach (string s in hs)
                {
                    if (!skip)
                    {
                        if (!skipTag)
                            sb.Append(s);
                    }
                    else
                    {
                        skipTag = s == "script";
                    }
    
                    skip = !skip;
                }
                return sb.ToString();
            }
