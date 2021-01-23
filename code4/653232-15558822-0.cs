    public class XmlTextReaderWithPath : XmlTextReader
    {
        private readonly Stack<string> _path = new Stack<string>();
    
        public string Path
        {
            get { return String.Join("/", _path.Reverse()); }
        }
    
        public XmlTextReaderWithPath(TextReader input)
            : base(input)
        {
        }
    
        // TODO: Implement the other constuctors as needed
    
        public override bool Read()
        {
            if (base.Read())
            {
                switch (NodeType)
                {
                    case XmlNodeType.Element:
                        _path.Push(LocalName);
                        break;
    
                    case XmlNodeType.EndElement:
                        _path.Pop();
                        break;
    
                    default:
                        // TODO: Handle other types of nodes, if needed
                        break;
                }
    
                return true;
            }
    
            return false;
        }
    }
