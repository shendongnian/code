    public sealed class MultiplyByTwoBlock : AbstractMultiplyBlock<int, int>
    {
        public MultiplyByTwoBlock()
            : base(new TransformBlock<int, int>(x => x * 2))
        {
        }
    }
    public sealed class MultiplyByThreeBlock : AbstractMultiplyBlock<int, int>
    {
        public MultiplyByThreeBlock()
            : base(new TransformBlock<int, int>(x => x * 3))
        {
        }
    }
