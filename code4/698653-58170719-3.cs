    public static class AutoFixtureExtensions
    {
        public static SetCreateProvider<TTypeToConstruct> For<TTypeToConstruct>(this IFixture fixture)
        {
            return new SetCreateProvider<TTypeToConstruct>(fixture);
        }
    }
