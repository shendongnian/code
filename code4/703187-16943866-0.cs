        public static string ReplaceTags(Match match)
        {
            if (match.Value.StartsWith("[url]") && match.Groups.Count == 4)
                return String.Format("<a href=\"{0}\">{0}</a>", match.Groups[2]);
            else if (match.Value.StartsWith("[img]") && match.Groups.Count == 4)
                return String.Format("<img src=\"{0}\" width=\"300\">", match.Groups[3]);
            throw new Exception("Unknown match found. Deal with it.");
        }
        static void Main(string[] args)
        {
            string text = "text[url]http://some_url[/url]text2[img]http://some/img.jpg[/img]text3";
            Regex regex = new Regex(@"(\[url](.*)\[/url]|\[img](.*)\[/img])");
            string result = regex.Replace(text, ReplaceTags);
            Console.WriteLine(result);
        }
