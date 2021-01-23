        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void MyTestMethod()
        {
            var list = new List<double>() { 1, 3, 5, 2, 9, 4 };
            var minmax = from l in list
                         group l by 1 into g
                         select new
                         {
                             min = g.Min(),
                             max = g.Max()
                         };
            minmax.First().min.Should().Be(1);
            minmax.First().max.Should().Be(9);
        }
