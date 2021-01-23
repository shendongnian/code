    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class PathToXmlNode : System.Attribute
    {
        public string Path { get; set; }
        public PathToXmlNode(string path)
        {
            this.Path = path;
        }
    }
