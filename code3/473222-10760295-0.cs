    internal interface A<out T>
        {
        }
        internal class B
        {
        }
        internal class C : B
        {
        }
        internal class My1
        {
        public My1(A<B> lessDerivedTemplateParameter)
        {
        }
    }
    internal class My2 : My1
    {
        public My2(A<C> moreDerivedTemplateParameter)
            : base(moreDerivedTemplateParameter) 
        {
        }
    }
