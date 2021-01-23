    public static class HqlTreeBuilderExtensions
    {
        public static HqlElements Elements(this HqlTreeBuilder treeBuilder, HqlExpression dictionary)
        {
            var factory = (IASTFactory) treeBuilder.GetType().GetField("_factory", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(treeBuilder);
            return new HqlElements(factory, dictionary);
        }
    }
