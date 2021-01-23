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
                object mock = Activator
                    .CreateInstance(typeof(Mock<>)
                    .MakeGenericType(type));
                mock.GetType()
                    .GetMethod("SetupAllProperties")
                    .Invoke(mock, new object[] { });
                var @object = mock
                    .GetType()
                    .GetProperty("Object", type)
                    .GetValue(mock);
                foreach (PropertyInfo propInfo in type.GetProperties())
                {
                    object value = context.Resolve(propInfo.PropertyType);
                    propInfo.SetValue(@object, value);
                }
                return @object;
            }
        }
    }
