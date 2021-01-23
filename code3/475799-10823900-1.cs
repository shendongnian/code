    [TestFixture]
    public class TestClass
    {
        private IEnumerable<Func<double, double, double>> TestCases
        {
            get
            {
                yield return (a, b) => a + b;
                yield return (a, b) => a * b;
                yield return (a, b) => a / b;
            }
        }
        [TestCaseSource("TestCases")]
        public void Test(Func<double, double, double> func)
        {
            Assert.GreaterOrEqual(func(1.0, 1.0), 1.0);
        }
    }
