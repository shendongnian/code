    public class ConfigBuilder
    {
        private string name;
        private int foo;
        private List<Element> elements = new List<Element>();
        public ConfigBuilder WithName(string name)
        {
             this.name = name;
             return this;
        }
	
        public ConfigBuilder WithFoo(int foo)
        {
            this.foo = foo;
            return this;
        }
	
        public ConfigBuilder WithElement(Element element)
        {
            elements.Add(element);
            return this;
        }
	
        public ConfigBuilder WithElement(ElementBuilder element)
        {
            return WithElement(element.Build());
        }
        public ConfigBuilder WithElement(Action<ElementBuilder> builderConfig)
        {
             var elementBuilder = new ElementBuilder();
             builderConfig(elementBuilder);
             return this.WithElement(elementBuilder);
        }
        public ConfigBuilder WithElements(params Action<ElementBuilder>[] builderConfigs)
        {
             foreach(var config in builderConfigs)
             {
                  this.WithElement(config);
             }
             return this;
        }
	
        public Config Build()
        {
             return new Config() 
             { 
                 Name = this.name,
                 Foo = this.foo,
                 Elements = this.elements
             };
        }
    }
    public class ElementBuilder
    {
        private string name;
        private int height;
	
        public ElementBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
	
        public ElementBuilder WithHeight(int height)
        {
            this.height = height;
            return this;
        }
	
        public Element Build()
        {
            return new Element() 
            { 
                Name = this.name,
                Height = this.height
            };
        }
    }
    public class Config
    {
        public string Name { get; set; }
        public int Foo { get; set; }
        public IList<Element> Elements { get; set; }
    }
    public class Element
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
