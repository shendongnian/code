    internal class GotoTagger : ITagger<GotoTag>
    {
        private ITextSearchService _textSearchService;
        private ITextStructureNavigator _textStructureNavigator;
    
        event EventHandler<SnapshotSpanEventArgs> ITagger<GotoTag>.TagsChanged { add { } remove { } }
    
        public GotoTagger(ITextSearchService textSearchService, ITextStructureNavigator textStructureNavigator)
        {
            _textSearchService = textSearchService;
            _textStructureNavigator = textStructureNavigator;
        }
    
        public IEnumerable<ITagSpan<GotoTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
                yield break;
    
            if (spans.Count > 0)
            {
                // look for 'goto' occurrences
                foreach (SnapshotSpan span in _textSearchService.FindAll(new FindData("goto", spans[0].Snapshot, FindOptions.WholeWord | FindOptions.MatchCase, _textStructureNavigator)))
                {
                    yield return new TagSpan<GotoTag>(span, new GotoTag());
                }
            }
        }
    }
    
        
        [Export(typeof(IViewTaggerProvider))]
        [TagType(typeof(TextMarkerTag))]
        [ContentType("code")] // only for code portion. Could be changed to csharp to colorize only C# code for example
        internal class GotoTaggerProvider : IViewTaggerProvider
        {
            [Import]
            internal ITextSearchService TextSearchService { get; set; }
        
            [Import]
            internal ITextStructureNavigatorSelectorService TextStructureNavigatorSelector { get; set; }
        
            public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
            {
                if (textView.TextBuffer != buffer)
                    return null;
        
                return new GotoTagger(TextSearchService, TextStructureNavigatorSelector.GetTextStructureNavigator(buffer)) as ITagger<T>;
            }
        }
        
        internal class GotoTag : TextMarkerTag
        {
            public GotoTag() : base("goto") { }
        }
        
        [Export(typeof(EditorFormatDefinition))]
        [Name("goto")]
        [UserVisible(true)]
        internal class GotoFormatDefinition : MarkerFormatDefinition
        {
            public GotoFormatDefinition()
            {
                BackgroundColor = Colors.Red;
                ForegroundColor = Colors.White;
                DisplayName = "Goto Word";
                ZOrder = 5;
            }
        }
