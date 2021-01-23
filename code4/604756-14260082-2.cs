    public class SomeFactory
    {
        public SomeClass GetSomeClass()
        {
              return new SomeClass(new SomeDep1(), new SomeDep2(new SomeInnerDep()));
        }
    }
