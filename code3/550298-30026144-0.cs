    public static string RemoveHtmlTags(string strHtml)
        {
            string strText = Regex.Replace(strHtml, "<(.|\n)*?>", String.Empty);
            strText = HttpUtility.HtmlDecode(strText);
            strText = Regex.Replace(strText, @"\s+", " ");
            return strText;
        }
