    interface IA<out T> { 
        public T GetSome();
    }
    class B { }
    
    class C : B { }
    
    class D : B { }
    
    class My1  {
        public My1(IA<B> lessDerivedTemplateParameter)
        {
           // This is totally legal
           var someB = lessDerivedTemplateParameter.GetSome();
        }
    }
    
    class My2 : My1 {
        public My2(IA<C> moreDerivedTemplateParameter)
            // This is allowed, because an A<C> only *produces* C's (which are also B's)
            // so the base class (which consumes B's, and doesnt care if they are C's) 
            // can use an IA<C>
            : base(moreDerivedTemplateParameter)
        {
        }
    }
