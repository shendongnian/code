    class LinePaddingTransformer : IVisualLineTransformer
    {
        private List<ClientLine> _clientLines;
        public const double PADDING = 5;
        public LinePaddingTransformer(List<ClientLine> clientLines)
        {
            _clientLines = clientLines;
        }
        public void Transform(ITextRunConstructionContext context, IList<VisualLineElement> elements)
        {
            int index = context.VisualLine.FirstDocumentLine.LineNumber - 1;
            double padding = GetLinePaddingMethod(index);  //You need to calculate your padding from the line index somehow here.
            context.VisualLine.LineSpacing= padding;
        }
    }
