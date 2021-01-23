    public class CustomJsonTextWriter : JsonTextWriter
    {
        private readonly Action<bool> _adjustDepth;
        public CustomJsonTextWriter(TextWriter textWriter, Action<bool> adjustDepth)
            : base(textWriter)
        {
            _adjustDepth = adjustDepth;
        }
        public override void WriteStartObject()
        {
            _adjustDepth(true);
            base.WriteStartObject();
        }
        public override void WriteEndObject()
        {
            _adjustDepth(false);
            base.WriteEndObject();
        }
    }
