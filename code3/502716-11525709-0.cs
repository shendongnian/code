    // nb: there is a bug in the VS designer which requires this type of extension
    // be used as an element if you embed another markup extension in it.
    public class FindFirstFileExtension : MarkupExtension
    {
        public Environment.SpecialFolder Root { get; set; }
        public string Paths { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(this.Paths)) return null;
            var root = Environment.GetFolderPath(this.Root);
            var uri = this.Paths
                          .Split(',')
                          .Select(p => Path.Combine(root, p))
                          .FirstOrDefault(p => File.Exists(p));
            return uri != null ? new Uri(uri) : null;
        }
    }
