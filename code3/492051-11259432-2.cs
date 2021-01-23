    [TestFixture]
    public class TestClass
    {
        private IEnumerable<Tuple<Func<object, object>, object> TestCases
        {
            get
            {
                var values = new object[,] { { 1, "test", 3 }, { 2, "hello", 0 }, ... };
                for (var i = 0; i < values.GetDimension(0); ++i)
                {
                    yield return x => Tuple.Create(_sut.Method1((int)x), values[i,0]);
                    yield return x => Tuple.Create(_sut.Method2((string)x), values[i,1]);
                    yield return x => Tuple.Create(_sut.Method3((int)x), values[i,2]);
                }
            }
        }
        [TestCaseSource("TestCases")]
        public void Test(Tuple<Func<object, object>, object> funcsVals)
        {
            Assert.That(funcsVals.Item1(funcsVals.Item2), Is.Null);
        }
    }
