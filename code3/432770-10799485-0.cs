    [Export(typeof(IViewTaggerProvider))]
    [ContentType("any")]
    [TagType(typeof(ClassificationTag))]
    public sealed class RegionTaggerProvider : IViewTaggerProvider
    {
        [Import]
        public IClassificationTypeRegistryService Registry;
        [Import]
        internal ITextSearchService TextSearchService { get; set; }
        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            if (buffer != textView.TextBuffer)
                return null;
            var classType = Registry.GetClassificationType("region-foreground");
            return new RegionTagger(textView, TextSearchService, classType) as ITagger<T>;
        }
    }
