    [TestFixture]
    public class TaskTester
    {
        [Test]
        public void Test()
        {
            Tuple<Task<int>, Task<double>> result = GetResult();
            result.Item1.Start();
            Assert.That(result.Item2.Result, Is.EqualTo(12));
        }
        private static Tuple<Task<int>, Task<double>> GetResult()
        {
            var task1 = new Task<int>(() => 10);
            Task<int> task2 = task1.ContinueWith(i => i.Result + 2);
            Task<double> task3 = task2.ContinueWith(i => (double)i.Result);
            return new Tuple<Task<int>, Task<double>>(task1, task3);
        }
    }
