    public class Document {
        public Element DocumentElement { set; get; }
        
        private void Load(string fileName) {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            DocumentElement = new Element(this, null);
            DocumentElement.Load(document.DocumentElement);
        }
    }
    public class Element {
        public string Name { set; get; }
        public string Value { set; get; }
        //other attributes
        
        private Document document = null;
        private Element parent = null;
        public Element Parent { get { return parent; } }
        public List<Element> Children { set; get; }
        private int order = 0;
        public Element(Document document, Element parent) {
            Name = "";
            Value = "";
            Children = new List<LayoutElement>();
            this.document = document;
            this.parent = parent;
            order = parent != null ? parent.Children.Count + 1 : 1;
        }
        private Element GetSibling(bool left) {
            if(parent == null) return null;
            int add = left ? -1 : +1;
            Element sibling = parent.Children.Find(child => child.order == order + add);
            return sibling;
        }
        public Element GetLeftSibling() {
            return GetSibling(true);
        }
        public Element GetRightSibling() {
            return GetSibling(false);
        }
        
        public void Load(XmlNode node) {
            Name = node.Name;
            Value = node.Value;
            //other attributes
            
            foreach(XmlNode nodeChild in node.Children) {
                Element child = new Element(document, this);
                child.Load(nodeChild);
                Children.Add(child);
            }
        }
    }
    Document document = new Document();
    document.Load(fileName);
