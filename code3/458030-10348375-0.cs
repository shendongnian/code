    public class Config
    {
        private string name;
        private IList<Element> elements = new List<Element>();
    
        public Config(string name)
        {
            this.name = name;
        }
    
        public Config WithElement(string name, int height)
        {
            elements.Add(new Element() { Name = name, Height = height });
            return this;
        }
    
        class Element
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
    }
