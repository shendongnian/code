    //Block is take from http://www.codeducky.org/razor-trick-using-block/
    public class TableRow : Block
    {
        private object _htmlAttributes;
        private TagBuilder _tr;
    
        public TableRow(HtmlHelper htmlHelper, object htmlAttributes) : base(htmlHelper)
        {
            _htmlAttributes = htmlAttributes;
        }
    
        public override void BeginBlock()
        {
            _tr = new TagBuilder("tr");
            _tr.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(_htmlAttributes));
            this.HtmlHelper.ViewContext.Writer.Write(_tr.ToString(TagRenderMode.StartTag));
        }
    
        protected override void EndBlock()
        {
            this.HtmlHelper.ViewContext.Writer.Write(_tr.ToString(TagRenderMode.EndTag));
        }
    }
