    // C.U.T.
    public class BadMaths
    {
        public int BadAdd(int x, int y) { return x + y - 1; }
        public int Divide(int x, int y) { return x / y; }
    }
    [TestFixture]
    public class BadMathsTest
    {
        public struct AdditionData
        {
            public int First { get; set; }
            public int Second { get; set; }
        }
        [Datapoints]
        private AdditionData[] _points = new AdditionData[]
        {
            new AdditionData{First=20, Second=10},
            new AdditionData{First=-10, Second=0}
        };
        public struct DivisionData
        {
            public int First { get; set; }
            public int Second { get; set; }
        }
        [Datapoints]
        private DivisionData[] _points2 = new DivisionData[]
        {
            new DivisionData{First=20, Second=10},
        };
        [Theory]
        public void AddTheory(AdditionData point)
        {
            Assume.That((long)point.First + (long)point.Second < (long)int.MaxValue);
            Assert.That(point.First + point.Second, Is.EqualTo(new BadMaths().BadAdd(point.First, point.Second)));
        }
        [Theory]
        public void DivideTheory(DivisionData point)
        {
            Assume.That(point.Second != 0); // Actually you probably want to keep this condition anyway. Second==0 would be a separate test
            Assert.That(point.First / point.Second, Is.EqualTo(new BadMaths().Divide(point.First, point.Second)));
        }
    }
