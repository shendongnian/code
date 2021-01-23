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
            private readonly Element element;
    
            // Constructor called from Elements...
            internal ElementBuilder(Config config)
            {
                this.config = config;
                this.element = null;
            }
    
            // Constructor called from each method below
            internal ElementBuilder(Element element)
            {
                this.config = null;
                this.element = element;
            }
    
            public ElementBuilder Name(string name)
            {
                return Mutate(e => e.Name = name);
            }
    
            public ElementBuilder Height(int height)
            {
                return Mutate(e => e.Height = height);
            }
            
            // Convenience method to avoid repeating the logic for each
            // property-setting method
            private ElementBuilder Mutate(Action<Element> mutation)
            {
                // First mutation call: create a new element, return
                // a new builder containing it.
                if (element == null)
                {
                    Element newElement = new Element();
                    config.elements.Add(newElement);
                    mutation(newElement);
                    return new ElementBuilder(newElement);
                }
                // Subsequent mutation: just mutate the element, return
                // the existing builder
                mutation(element);
                return this;
            }
        }
    
        public class Element
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
    }
