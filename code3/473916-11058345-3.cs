    public class TextViewModel
    {
        public string FullText { get { return "Full text"; } }
        public string ShortText { get { return "Short text"; } }
        public string ViewMode { get; private set; }
        public TextViewModel(string viewMode)
        {
            if (!string.IsNullOrWhiteSpace(viewMode))
                this.ViewMode = viewMode.Trim().ToLower();
        }
    }
