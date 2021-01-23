    class B { }
    
    class C : B { }
    
    class D : B { }
    
    class My1  {
        public My1(List<B> lessDerivedTemplateParameter)
        {
           // This is totally legal
           lessDerivedTemplateParameter.Add(new D());
        }
    }
    
    class My2 : My1 {
        public My2(List<C> moreDerivedTemplateParameter)
            // if this were allowed, then My1 could add a D to a list of Bs
            : base(moreDerivedTemplateParameter)
        {
        }
    }
