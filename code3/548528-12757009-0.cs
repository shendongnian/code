    public class RenderObject : Tag
    {
        private string _tagName;
        private string _markup;
        public override void Initialize(string tagName, string markup, List<string> tokens)
        {
            _tagName = tagName;
            _markup = markup.Trim();
            base.Initialize(tagName, markup, tokens);
        }
        public override void Render(Context context, TextWriter result)
        {
            var structure = context[_markup];
        }
    }
