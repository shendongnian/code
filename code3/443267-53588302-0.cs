    public static string RemoveHTMLTags(string value)
        {
            string step1 = Regex.Replace(value, "<[^>]*>", " ");
            string step2 = HttpUtility.HtmlDecode(step1);
            return step2;
        }
