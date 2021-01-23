    [TestFixture]
    public class LinqSortTest
    {
        public class MonthlyConsumption
        {
            public string Unit { get; set; }
            public List<DailyConsumption> DailyConsumptions { get; set; }
        }
        public class DailyConsumption
        {
            public DateTime Day { get; set; }
            public double? Value { get; set; }
        }
        [Test]
        public void SomeTest()
        {
            var targetDay = new DateTime(2013, 1, 1);
            var monthlyConsumptions = new List<MonthlyConsumption>();
            monthlyConsumptions.Add(new MonthlyConsumption
                {
                    Unit = "first",
                    DailyConsumptions = new List<DailyConsumption>
                        {
                                    new DailyConsumption { Day = new DateTime(2013, 1, 1), Value = 5 },
                                    new DailyConsumption { Day = new DateTime(2013, 1, 5), Value = 100 }
                        }
                });
            monthlyConsumptions.Add(
                new MonthlyConsumption
                    {
                        Unit = "second",
                        DailyConsumptions =
                            new List<DailyConsumption>
                                {
                                    new DailyConsumption { Day = new DateTime(2013, 1, 1), Value = 2 },
                                    new DailyConsumption { Day = new DateTime(2013, 1, 5), Value = 1 }
                                }
                    });
            var result =
                monthlyConsumptions.OrderBy(
                    x =>
                    x.DailyConsumptions.Where(y => y.Day.Date == targetDay.Date).Select(
                        z => (!z.Value.HasValue ? 0 : z.Value.Value)).SingleOrDefault()).ToList();
            Assert.AreEqual("second", result[0].Unit);
        }
    }
