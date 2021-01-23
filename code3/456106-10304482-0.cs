    public static class NavigationLinksExtension
    {
        public static string GetFriendlyName(this NavigationLinks navLink)
        {
            string tmpName = navLink.ToString();
            tmpName = Regex.Replace(tmpName, "(?<=[a-z])([A-Z])", " $1"); // insert space
            return tmpName;
        }
    }
