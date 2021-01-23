    public class BarTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2 };
            yield return new object[] { -4, -6 };
            yield return new object[] { 2, 4 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    [Theory]
    [ClassData(typeof(BarTestData))]
    public void BarTestB(int value1, int value2)
    {
        Assert.True(value1 + value2 < 7)
    }
