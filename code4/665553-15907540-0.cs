    public class StringProperty : ItemProperty
    {
        public string RawProp { get; set; }
        public string RenderedProp { get; set; }
        public static implicit operator string(StringProperty p)
        {
            return p.RenderedProp;
        }
    }
