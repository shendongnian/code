    public class MyClass
    {
        public MyClass()
        {
            _blocks = new Lazy<IEnumerable<int>>(() => this.CalculateBlocks(0).FirstOrDefault());
        }
        private readonly Lazy<IEnumerable<int>> _blocks;
    }
