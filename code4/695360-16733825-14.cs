    public class MyTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                new TypeRelay(typeof(IMyInterface), typeof(FakeMyInterface)));
        }
    }
