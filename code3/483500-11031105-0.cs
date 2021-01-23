        /// <summary>
        /// Hyperlink button - simulates hyperlink click
        /// </summary>
        private class HyperlinkButtonWrapper : HyperlinkButton
        {
            public void OpenURL(string navigateUri)
            {
                OpenURL(new Uri(navigateUri, UriKind.Absolute));
            }
            public void OpenURL(Uri navigateUri)
            {
                base.NavigateUri = navigateUri;
                base.TargetName = "_blank";
                base.OnClick();
            }
        }
        /// <summary>
        /// Method opens url
        /// <para>Example: OpenURL("http://www.google.com")</para>
        /// </summary>
        /// <param name="navigateUri"></param>
        public static void OpenURL(string navigateUri)
        {
            new HyperlinkButtonWrapper().OpenURL(navigateUri);
        }
