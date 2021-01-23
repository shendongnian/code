    public class Foo 
    {
        private static Random randGen = new Random();
        public void Foo()
        {
            int i = this.randGen.Next();
        }
        public void Bar()
        {
            int j = this.randGen.Next();
        }
        public void ReseedRandomNumberGenerator(int? seed = null)
        {
            this.randGen = seed.HasValue ? new Random(seed.Value) : new Random();
        }
    }
