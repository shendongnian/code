    public static class NavigationCreator
    {
        public static void SetUrl(BaseContact contact, HyperLink link)
        {
            link.NavigateUrl = contact.Url;
        }
    }
