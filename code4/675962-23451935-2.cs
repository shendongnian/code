    public static class AssertionsExtensions
    {
        public static void DeepEquals(this Assertions assertions, XNode expected, XNode actual)
        {
            assertions.True(XNode.DeepEquals(expected, actual)); // You can also use Assert.True here, there's effectively no difference.
        }
    }
