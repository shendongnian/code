    foreach (HtmlNode link in root.SelectNodes("//script"))
    {
        if (link.InnerText.Contains("+a+"))
        {
            string[] strs = new string[] { "var a='", "';document.write" };
            strs = link.InnerText.Split(strs, StringSplitOptions.None);
            outMail = System.Net.WebUtility.HtmlDecode(strs[1]);
            if (outMail != "")
            {
                break;
            }
        }
    }
