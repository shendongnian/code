    internal class InlineAutoMockDataAttribute : CompositeDataAttribute
    {
        internal InlineAutoMockDataAttribute (params object[] values)
            : base(
                new InlineDataAttribute(values),
                new AutoDataAttribute(
                    new Fixture().Customize(
                        new CompositeCustomization(
                            new AutoMoqCustomization()))))
        {
        }
    }
