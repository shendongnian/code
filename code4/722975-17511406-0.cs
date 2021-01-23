    public class LyricsItem
    {
        public LyricsItem()
        {
        }
        public LyricsItem(LyricsItem item)
        {
            this.searchUrl = item.searchUrl;
            this.croppingRegex = item.croppingRegex;
        }
        private string _searchUrl;
        private string _croppingRegex;
        public string searchUrl
        {
            get { return _searchUrl; }
            set { _searchUrl = value; }
        }
        public string croppingRegex
        {
            get { return _croppingRegex; }
            set { _croppingRegex = value; }
        }
    }
