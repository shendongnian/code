    [TestFixture]
    public class TestClass
    {
        private IEnumerable<Tuple<Func<object, object>, object> TestCases
        {
            get
            {
                yield return x => Tuple.Create(_sut.Method1((int)x), 1);
                yield return x => Tuple.Create(_sut.Method2((string)x), "test");
                yield return x => Tuple.Create(_sut.Method3((int)x), 3);
            }
        }
        [TestCaseSource("TestCases")]
        public void Test(Tuple<Func<object, object>, object> funcsVals)
        {
            Assert.That(funcsVals.Item1(funcsVals.Item2), Is.Null);
        }
    }
