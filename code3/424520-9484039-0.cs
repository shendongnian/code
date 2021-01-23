    public class MyClass
    {   
        public string Title { get; set; }
        
        Xml _xml;
        public Xml MyXml
        {
            get { return _xml; }
            set { _xml = value; }
        }    
        
        public MyClass(string xmlName, object xmlAttributes)
        {
            _xml = new Xml(xmlName, xmlAttributes);        
        }
        
            public class Xml
            {
                private readonly string _name;
                public string Name
                {
                    get { return _name; }
                }
                
                private readonly object _attributes;
                internal object Attributes
                {
                    get { return _attributes; }
                }
                
                public Xml(string name, object attributes)
                {
                    _name = name;
                    _attributes = attributes;
                }
            }
    }
