    public class Foo()
    {
        public ISpecification<Foo> Specification 
        {
            get;
            private set;
        }
        
        public Foo(ISpecification<Foo> specification)
        {
            this.Specification = specification;
        }
        
        public void DoSomething()
        { 
            if(specification.SatisfiedBy(this)
            {
                //...
            }
        }
    }
