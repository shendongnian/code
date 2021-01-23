    public string EntityToUnicode(string html) {
            var replacements = new Dictionary<string, string>();
            var regex = new Regex("(&[a-zA-Z]{2,11};)");
            foreach (Match match in regex.Matches(html)) {
                if (!replacements.ContainsKey(match.Value)) { 
                    var unicode = HttpUtility.HtmlDecode(match.Value);
                    if (unicode.Length == 1) {
                        replacements.Add(match.Value, string.Concat("&#", Convert.ToInt32(unicode[0]), ";"));
                    }
                }
            }
            foreach (var replacement in replacements) {
                html = html.Replace(replacement.Key, replacement.Value);
            }
            return html;
        }
