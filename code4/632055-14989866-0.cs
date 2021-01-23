    internal class WebModelCustomization : CompositeCustomization
    {
        internal WebModelCustomization()
            : base(
                new MvcCustomization(),
                new AutoMoqCustomization())
        {
        }
        private class MvcCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize<ControllerContext>(c => c
                    .Without(x => x.DisplayMode));
            }
        }
    }
 
