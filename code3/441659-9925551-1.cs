    public static string ClearHtmlTags(string html)
            {
                if (string.IsNullOrWhiteSpace(html)) 
                    return html;
    
                html = html.Trim();
                string[] hs = html.Split("<>".ToArray());
                bool skip = false;
    
                StringBuilder sb = new StringBuilder();
                foreach (string s in hs)
                {
                    if (!skip)
                        sb.Append(s);
    
                    skip = !skip;
                }
                return sb.ToString();
            }
