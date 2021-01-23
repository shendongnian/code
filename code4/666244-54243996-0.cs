    public class StringExtensionTests
    {
        [Theory]
        [InlineData("Text", typeof(string), true)]
        [InlineData("", typeof(string), true)]
        [InlineData("Text", typeof(int), false)]
        [InlineData("128", typeof(int), true)]
        [InlineData("0", typeof(int), true)]
        public void ShouldCheckIsValidType(string value, Type type, bool expectedResult)
        {
            var methodInfo = typeof(StringExtensions).GetMethod(nameof(StringExtensions.IsValidType),
                new[] { typeof(string) });
            var genericMethod = methodInfo.MakeGenericMethod(type);
            var result = genericMethod.Invoke(null, new[] { value });
            result.Should().Be(expectedResult);
        }
    }
