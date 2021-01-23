    class LinePaddingTransformer : IVisualLineTransformer
    {
        public LinePaddingTransformer()
        {
   
        }
        public void Transform(ITextRunConstructionContext context, IList<VisualLineElement> elements)
        {
            int index = context.VisualLine.FirstDocumentLine.LineNumber - 1;
           //You need to calculate your padding from the line index somehow.
           //for example create a list of objects with the spacing in them and pass to this transformer.
            double spacing= MyCalculateLinePaddingMethod(index);  
            context.VisualLine.LineSpacing= spacing;
        }
    }
