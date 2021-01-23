    public static IPropagatorBlock<int, int> CreateMultiplyIntTransformBlock(
        int multiplier)
    {
        return new TransformBlock<int, int>(i => i * multiplier);
    }
    public static IPropagatorBlock<int, int> CreateMultiplyIntByTwoTransformBlock()
    {
        return CreateMultiplyIntTransformBlock(2);
    }
