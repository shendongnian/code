    public sealed class RegionTagger : ITagger<ClassificationTag>
    {
        private readonly ITextView m_View;
        private readonly ITextSearchService m_SearchService;
        private readonly IClassificationType m_Type;
        private NormalizedSnapshotSpanCollection m_CurrentSpans;
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged = delegate { };
        public RegionTagger(ITextView view, ITextSearchService searchService, IClassificationType type)
        {
            m_View = view;
            m_SearchService = searchService;
            m_Type = type;
            m_CurrentSpans = GetWordSpans(m_View.TextSnapshot);
            m_View.GotAggregateFocus += SetupSelectionChangedListener;
        }
        private void SetupSelectionChangedListener(object sender, EventArgs e)
        {
            if (m_View != null)
            {
                m_View.LayoutChanged += ViewLayoutChanged;
                m_View.GotAggregateFocus -= SetupSelectionChangedListener;
            }
        }
        private void ViewLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            if (e.OldSnapshot != e.NewSnapshot)
            {
                m_CurrentSpans = GetWordSpans(e.NewSnapshot);
                TagsChanged(this, new SnapshotSpanEventArgs(new SnapshotSpan(e.NewSnapshot, 0, e.NewSnapshot.Length)));
            }
        }
        private NormalizedSnapshotSpanCollection GetWordSpans(ITextSnapshot snapshot)
        {
            var wordSpans = new List<SnapshotSpan>();
            wordSpans.AddRange(FindAll(@"#region", snapshot).Select(regionLine => regionLine.Start.GetContainingLine().Extent));
            wordSpans.AddRange(FindAll(@"#endregion", snapshot).Select(regionLine => regionLine.Start.GetContainingLine().Extent));
            return new NormalizedSnapshotSpanCollection(wordSpans);
        }
        private IEnumerable<SnapshotSpan> FindAll(String searchPattern, ITextSnapshot textSnapshot)
        {
            if (textSnapshot == null)
                return null;
            return m_SearchService.FindAll(
                new FindData(searchPattern, textSnapshot) {
                        FindOptions = FindOptions.WholeWord | FindOptions.MatchCase
                    });
        }
        public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (spans == null || spans.Count == 0 || m_CurrentSpans.Count == 0)
                yield break;
            ITextSnapshot snapshot = m_CurrentSpans[0].Snapshot;
            spans = new NormalizedSnapshotSpanCollection(spans.Select(s => s.TranslateTo(snapshot, SpanTrackingMode.EdgeExclusive)));
            foreach (var span in NormalizedSnapshotSpanCollection.Intersection(m_CurrentSpans, spans))
            {
                yield return new TagSpan<ClassificationTag>(span, new ClassificationTag(m_Type));
            }
        }
    }
