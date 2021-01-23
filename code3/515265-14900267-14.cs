    public class PagePart {}
    public class LiteralPart : PagePart
    {
        public LiteralPart(string text) { Text = text; }
        public string Text { get; private set; }
    }
    public class PlaceHolderPart : PagePart
    {
        public PlaceHolderPart(PlaceHolderType type) { Type = type; }
        public PlaceHolderType Type { get; private set; }
    }
    public enum PlaceHolderType { Title, Head, Main }
