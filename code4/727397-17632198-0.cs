    class AssociationUriMapper : UriMapperBase
    {
        public bool uidFound;
        private string tempUri;
        public override Uri MapUri(Uri uri)
        {
            tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
            // URI association launch for my app detected
            if (tempUri.Contains("mycustomuri:uid?uid="))
            {
                // Get the category (after "Category=").
                int uidIndex = tempUri.IndexOf("uid=")+7;
                string uid = tempUri.Substring(uidIndex);
                // Redirect to the MainPage.xaml with the proper category to be displayed
                return new Uri("/DetectTag.xaml?uid=" + uid, UriKind.Relative);
            }
            // Otherwise perform normal launch.
            return uri;
        }
    }
