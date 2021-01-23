    public class MyTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                new TypeReleay(typeof(IMyInterface), typeof(FakeMyInterface));
        }
    }
