    var jObj = JObject.Parse(json);
    var frameDict = jObj["frames"].Children()
                   .OfType<JProperty>()
                   .ToDictionary(p => p.Name, p => p.Value.ToObject<Frame>());
    public class Rect
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }
    public class SSize
    {
        public int w { get; set; }
        public int h { get; set; }
    }
    public class Frame
    {
        public Rect frame { get; set; }
        public bool rotated { get; set; }
        public bool trimmed { get; set; }
        public Rect spriteSourceSize { get; set; }
        public SSize sourceSize { get; set; }
    }
