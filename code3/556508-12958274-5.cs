    internal class MyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new MySpecimenBuilder());
        }
        private class MySpecimenBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                var type = request as Type;
                if (type == null || !type.IsInterface)
                {
                    return new NoSpecimen(request);
                }
                object specimen = this
                    .GetType()
                    .GetMethod(
                        "Create",
                        BindingFlags.NonPublic | BindingFlags.Static)
                    .MakeGenericMethod(new[] { type })
                    .Invoke(this, new object[] { context });
                return specimen;
            }
            private static object Create<TRequest>(ISpecimenContext context)
                where TRequest : class
            {
                var mock = new Mock<TRequest>();
                mock.SetupAllProperties();
                foreach (PropertyInfo propInfo in typeof(TRequest).GetProperties())
                {
                    object value = context.Resolve(propInfo.PropertyType);
                    propInfo.SetValue(mock.Object, value);
                }
                return mock.Object;
            }
        }
    }
