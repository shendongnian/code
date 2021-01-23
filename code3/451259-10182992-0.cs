    class UrlText : IEquatable<UrlText>
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public UrlText(string url, string text)
        {
            this.Url = url;
            this.Text = text;
        }
        #region IEquatable<UrlText> Members
        public bool Equals(UrlText other)
        {
            return this.Url.Equals(other.Url);
        }
        #endregion
    }
