    public class HTMLWokExtend : HTMLWorker
    {
        LineSeparator line = new LineSeparator(1f, 90f, BaseColor.GRAY, Element.ALIGN_CENTER, -12);
        public HTMLWokExtend(IDocListener document) : base(document)
        {
    
        }
        public override void StartElement(string tag, IDictionary<string, string> str)
        {
            if (tag.Equals("hrline"))
                document.Add(new Chunk(line));
            else
                base.StartElement(tag, str);
        }
    }
