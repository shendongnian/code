    public class NavHtmlTextWritter : HtmlTextWriter
    {
        private Dictionary<HtmlTextWriterAttribute, List<string>> attrValues = new Dictionary<HtmlTextWriterAttribute, List<string>>();
        private HtmlTextWriterAttribute[] multiValueAttrs = new[] { HtmlTextWriterAttribute.Class };
        public NavHtmlTextWritter (TextWriter writer) : base(writer) { } 
        public override void AddAttribute(HtmlTextWriterAttribute key, string value)
        {
            if (multiValueAttrs.Contains(key))
            {
                if (!this.attrValues.ContainsKey(key))
                    this.attrValues.Add(key, new List<string>());
                this.attrValues[key].Add(value);
            }
            else
            {
                base.AddAttribute(key, value);
            }
        }
        public override void RenderBeginTag(HtmlTextWriterTag tagKey)
        {
            this.addMultiValuesAttrs();
            base.RenderBeginTag(tagKey);
        }
        public override void RenderBeginTag(string tagName)
        {
            this.addMultiValuesAttrs();
            base.RenderBeginTag(tagName);
        }
        private void addMultiValuesAttrs()
        {
            foreach (var key in this.attrValues.Keys)
                this.AddAttribute(key.ToString(), string.Join(" ", this.attrValues[key].ToArray()));
            this.attrValues = new Dictionary<HtmlTextWriterAttribute, List<string>>();
        }
    }
