    public class Test
    {
        protected ImmutableClass ImmutableMember {get; private set;}
    
        public Test()
            :this(new ImmutableClasse())
        {
        }
    
        public Test(ImmutableClass immutableClass)
        {
            ImmutableMember = new ImmutableClasse();
        }
    }
