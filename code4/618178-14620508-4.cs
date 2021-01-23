    public class ClipboardHtmlOutput
    {
        public Double Version { get; private set; }
        public String Source { get; private set; }
        public String Input { get; private set; }
        //public String Html { get { return Input.Substring(startHTML, (endHTML - startHTML)); } }
        public String Html { get { return Input.Substring(startHTML, Math.Min(endHTML - startHTML, Input.Length - startHTML)); } }
        public String Fragment { get { return Input.Substring(startFragment, (endFragment - startFragment)); } }
        private int startHTML;
        private int endHTML;
        private int startFragment;
        private int endFragment;
        public static ClipboardHtmlOutput ParseString(string s)
        {
            ClipboardHtmlOutput html = new ClipboardHtmlOutput();
            string pattern = @"Version:(?<version>[0-9]+(?:\.[0-9]*)?).+StartHTML:(?<startH>\d*).+EndHTML:(?<endH>\d*).+StartFragment:(?<startF>\d+).+EndFragment:(?<endF>\d*).+SourceURL:(?<source>f|ht{1}tps?://[-a-zA-Z0-9@:%_\+.~#?&//=]+)";
            Match match = Regex.Match(s, pattern, RegexOptions.Singleline);
            if (match.Success)
            {
                try
                {
                    html.Input = s;
                    html.Version = Double.Parse(match.Groups["version"].Value, CultureInfo.InvariantCulture);
                    html.Source = match.Groups["source"].Value;
                    html.startHTML = int.Parse(match.Groups["startH"].Value);
                    html.endHTML = int.Parse(match.Groups["endH"].Value);
                    html.startFragment = int.Parse(match.Groups["startF"].Value);
                    html.endFragment = int.Parse(match.Groups["endF"].Value);
                }
                catch (Exception fe)
                {
                    return null;
                }
                return html;
            }
            return null;
        }
    }
