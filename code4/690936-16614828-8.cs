    internal class AutoDomainDataAttribute : CompositeDataAttribute
    {
        internal AutoDomainDataAttribute()
            : base(
                new AutoDataAttribute(
                    new Fixture().Customize(
                        new AutoFakeItEasyCustomization())))
        {
        }
    }
