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
                ParameterExpression parameter = Expression.Parameter(type);
                foreach (PropertyInfo propInfo in type.GetProperties())
                {
                    MemberExpression body = Expression
                        .PropertyOrField(parameter, propInfo.Name);
                    object value = context.Resolve(propInfo.PropertyType);
                    this.GetType()
                        .GetMethod("SetupProperty",
                            BindingFlags.NonPublic | BindingFlags.Static)
                        .MakeGenericMethod(type)
                        .Invoke(this, new[] { mock, body, parameter, value });
                }
                return mock
                    .GetType()
                    .GetProperty("Object", type)
                    .GetValue(mock);
            }
            private static void SetupProperty<T>(Mock<T> mock,
                MemberExpression body,
                ParameterExpression parameter,
                object value) where T : class
            {
                mock.Setup(Expression.Lambda<Func<T, object>>(body, parameter))
                    .Returns(value);
            }
        }
