    public class ConcreteClassYImplementationOne : AbstractLibraryClassY
    {
        public override int MethodA(int SomeParam)
        {
            return SomeParam * this.Multiplier;
        }
    }
    public class ConcreteClassYImplementationTwo : AbstractLibraryClassY
    {
        public override int MethodA(int SomeParam)
        {
            return SomeParam * this.Multiplier + 5;
        }
    }
