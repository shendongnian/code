    public class ButtonsXml
    {
        XElement self;
        Dictionary<string, DataCollection> list = new Dictionary<string, DataCollection>();
    
        public ButtonsXml(string file)
        {
            self = XElement.Load(file);
        }
    
        public DataCollection this[string name]
        {
            get
            {
                if (list.ContainsKey(name))
                    return list[name];
                DataCollection c = new DataCollection(self.GetElement(name));
                list.Add(name, c);
                return c;
            }
        }
        public void Save(string file)
        {
            self.Save(file);
        }
    }
    
    public class DataCollection
    {
        XElement self;
        public Dictionary<int, Element> list = new Dictionary<int,Element>();
    
        public DataCollection(XElement self)
        {
            this.self = self;
        }
    
        public Element this[int index]
        {
            get
            {
                if (list.ContainsKey(index))
                    return list[index];
                Element e = new Element(self, index);
                list.Add(index, e);
                return e;
            }
        }
    }
    
    public class Element
    {
        XElement parent;
        int index;
    
        public Element(XElement parent, int index)
        {
            this.parent = parent;
            this.index = index;
        }
    
        public string Path
        {
            get { return parent.GetString("path" + index.ToString(), string.Empty); }
            set { parent.Set("path" + index.ToString(), value, XElementConversions.ELEMENT); }
        }
        public string Link
        {
            get { return parent.GetString("link" + index.ToString(), string.Empty); }
            set { parent.Set("link" + index.ToString(), value, XElementConversions.ELEMENT); }
        }
    }
