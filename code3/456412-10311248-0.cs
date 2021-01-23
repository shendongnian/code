    public static class Navigator
    {
        public static void Navigate(Page page, string frame)
        {
            page.NavigationService.Navigate(new Uri(string.Format("/{0}.xaml", frame), UriKind.Relative));
        }
    }
