    using System;
    using System.Collections.Generic;
    
    public class Config
    {
        private string name;
        private int foo;
        private IList<Element> elements = new List<Element>();
        
        public Config Name(string name)
        {
            this.name = name;
            return this;
        }
        
        public Config Foo(int x)
        {
            this.foo = x;
            return this;
        }
    
        public Config Elements(Action<ElementBuilder> builderAction)
        {
            ElementBuilder builder = new ElementBuilder(this);
            builderAction(builder);
            return this;
        }
        
        public class ElementBuilder
        {
            private readonly Config config;
            
            internal ElementBuilder(Config config)
            {
                this.config = config;
            }
            
            public ElementHeightBuilder Name(string name)
            {
                Element element = new Element { Name = name };
                config.elements.Add(element);
                return new ElementHeightBuilder(element);
            }
        }
        
        public class ElementHeightBuilder
        {
            private readonly Element element;
            
            internal ElementHeightBuilder(Element element)
            {
                this.element = element;
            }
    
            public void Height(int height)
            {
                element.Height = height;
            }
        }
    
        public class Element
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
    }
    
    
    
    class Test
    {
        static void Main()
        {
            Config config = new Config();
            
            config.Name("Foo")
                .Elements(e => {
                    e.Name("element1").Height(23);
                    e.Name("element2").Height(31);
                })
                .Foo(3232);
        }
    }
