       public static class CollectionAssertExtensions
        {
            public static void CollectionAreEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            {
                JsonConvert.SerializeObject(actual).Should().Be.EqualTo(JsonConvert.SerializeObject(expected));
            }
        }
