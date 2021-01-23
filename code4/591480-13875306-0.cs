    public class MvcCostumization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                new FilteringSpecimenBuilder(
                    new MethodInvoker(new ModestConstructorQuery()),
                    new ControllerSpecification()));
        }
        private class ControllerSpecification : IRequestSpecification
        {
            public bool IsSatisfiedBy(object request)
            {
                var t = request as Type;
                if (t == null)
                    return false;
                return typeof(ControllerBase).IsAssignableFrom(t);
            }
        }
    }
