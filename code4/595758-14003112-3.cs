     public List<Result> results {
            get
            {  
                return _results;
            }
            set
            {
                string x = null;
                foreach (var item in value)
                {
                    item.text2 = item.text;
                    if (!item.text.StartsWith("<Section"))
                        if(!item.text.Contains("</Run>"))
                    {
                        String xamlData = null;
                        var regx = new Regex(@query.Trim(), RegexOptions.IgnoreCase);
                        var matcches = regx.Matches(item.text);
                        x += matcches.Count;
                        if (matcches.Count > 0)
                        {
                            var match = @query.Trim();
                            xamlData = Regex.Replace(item.text, match, "<Run Foreground="Blue" FontWeight=\"ExtraBold\">" + match + "</Run>", RegexOptions.IgnoreCase);
                        }
                        if (xamlData == null)
                            xamlData = item.text;
                        item.text = "<Section xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>" + xamlData + "</Paragraph></Section>";
                    }
                }
                _results = value;
            }
        }
