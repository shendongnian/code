    public class MockHybridCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                new MockPostprocessor(
                    new MethodInvoker(
                        new MockConstructorQuery())));
            fixture.Customizations.Add(
                new Postprocessor(
                    new MockRelay(t =>
                        t == typeof(MyObject) || t == typeof(MyParent)),
                    new AutoExceptMoqPropertiesCommand().Execute,
                    new AnyTypeSpecification()));
        }
    }
