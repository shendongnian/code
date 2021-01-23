    public class Test
    {
        protected readonly ImmutableClass ImmutableMember;
    }
    
    public class SpecialTest : Test
    {
        public SpecialTest() { ImmutableMember = new ImmutableClass; }
    }
