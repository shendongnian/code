    private static void CompareIEnumerable<T>(IEnumerable<T> one, IEnumerable<T> two, Func<T, T, bool> comparisonFunction)
        {
            var oneArray = one as T[] ?? one.ToArray();
            var twoArray = two as T[] ?? two.ToArray();
            if (oneArray.Length != twoArray.Length)
            {
                Assert.Fail("Collections are not same length");
            }
            for (int i = 0; i < oneArray.Length; i++)
            {
                var isEqual = comparisonFunction(oneArray[i], twoArray[i]);
                Assert.IsTrue(isEqual);
            }
        }
