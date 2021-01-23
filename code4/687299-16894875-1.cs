    [TestFixture]
    public class BadMathsAdditionTest
    {
        // Ideally I want 2 x different datapoints - one for Add, and a different one for divide
        [Datapoints]
        private Tuple<int, int>[] _points = new Tuple<int, int>[]
        {
           new Tuple<int, int>(20, 10),
           new Tuple<int, int>(-10, 0),
        };
        // add tests that use these datapoints
        [Theory]
        public void AddTheory(Tuple<int, int> point)
        {
            Assume.That((long)point.Item1 + (long)point.Item2 < (long)int.MaxValue);
            Assert.That(point.Item1 + point.Item2, Is.EqualTo(new BadMaths().BadAdd(point.Item1, point.Item2)));
        }
    }
    [TestFixture]
    public class BadMathsDivisionTest
    {
        // Ideally I want 2 x different datapoints - one for Add, and a different one for divide
        [Datapoints]
        private Tuple<int, int>[] _points = new Tuple<int, int>[]
        {
           new Tuple<int, int>(20, 10),
        };
        // add test that use these datapoints
    }
