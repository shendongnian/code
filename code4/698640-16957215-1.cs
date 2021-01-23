    public static class FreezeByNameExtension
    {
        public static void FreezeByName<T>(this IFixture fixture, string name, T value)
        {
            fixture.Customizations.Add(new ParameterNameSpecimenBuilder<T>(name, value));
        }
    }
