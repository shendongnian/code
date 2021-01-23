    [TestClass]
    public class LinqIntervalQueryTest
    {
        public class Item
        {
            public int Id { get; set; }
            public int SensorId { get; set; }
            public double Value { get; set; }
            public DateTime CreatedOn { get; set; }
        }
        [TestMethod]
        public void Test()
        {
            var data = new[]
                {
                    new Item { Id = 1, SensorId = 8, Value = 33.5, CreatedOn = new DateTime(2012, 11, 15, 17, 48, 0, DateTimeKind.Utc) },
                    new Item { Id = 2, SensorId = 5, Value = 49.2, CreatedOn = new DateTime(2012, 11, 15, 17, 48, 0, DateTimeKind.Utc) },
                    new Item { Id = 3, SensorId = 8, Value = 33.2, CreatedOn = new DateTime(2012, 11, 15, 17, 49, 0, DateTimeKind.Utc) },
                    new Item { Id = 4, SensorId = 5, Value = 48.5, CreatedOn = new DateTime(2012, 11, 15, 17, 49, 0, DateTimeKind.Utc) },
                    new Item { Id = 5, SensorId = 8, Value = 31.8, CreatedOn = new DateTime(2012, 11, 15, 17, 50, 0, DateTimeKind.Utc) },
                    new Item { Id = 6, SensorId = 5, Value = 42.5, CreatedOn = new DateTime(2012, 11, 15, 17, 50, 0, DateTimeKind.Utc) },
                    new Item { Id = 7, SensorId = 8, Value = 36.5, CreatedOn = new DateTime(2012, 11, 15, 17, 51, 0, DateTimeKind.Utc) },
                    new Item { Id = 8, SensorId = 5, Value = 46.5, CreatedOn = new DateTime(2012, 11, 15, 17, 51, 0, DateTimeKind.Utc) },
                    new Item { Id = 9, SensorId = 8, Value = 39.2, CreatedOn = new DateTime(2012, 11, 15, 17, 52, 0, DateTimeKind.Utc) },
                    new Item { Id = 10, SensorId = 5, Value = 44.4, CreatedOn = new DateTime(2012, 11, 15, 17, 52, 0, DateTimeKind.Utc) },
                    new Item { Id = 11, SensorId = 8, Value = 36.5, CreatedOn = new DateTime(2012, 11, 15, 17, 53, 0, DateTimeKind.Utc) },
                    new Item { Id = 12, SensorId = 5, Value = 46.5, CreatedOn = new DateTime(2012, 11, 15, 17, 53, 0, DateTimeKind.Utc) },
                    new Item { Id = 13, SensorId = 8, Value = 39.2, CreatedOn = new DateTime(2012, 11, 15, 17, 54, 0, DateTimeKind.Utc) },
                    new Item { Id = 14, SensorId = 5, Value = 44.4, CreatedOn = new DateTime(2012, 11, 15, 17, 54, 0, DateTimeKind.Utc) },
                };
            var interval = TimeSpan.FromMinutes(3);
            var startDate = data.First().CreatedOn;
            var endDate = data.Last().CreatedOn;
            var numberOfPoints = (int)((endDate - startDate + interval).Ticks / interval.Ticks);
            var points = Enumerable.Range(0, numberOfPoints).Select(x => startDate.AddTicks(interval.Ticks * x));
            var query = from item in data
                        group item by item.SensorId
                        into g
                        from point in points
                        let itemToUse = g.LastOrDefault(x => x.CreatedOn <= point)
                        orderby itemToUse.CreatedOn, g.Key
                        select new
                            {
                                itemToUse.CreatedOn,
                                itemToUse.Value,
                                SensorId = g.Key
                            };
            var results = query.ToList();
            Assert.AreEqual(6, results.Count);
            Assert.AreEqual(data[1].CreatedOn, results[0].CreatedOn);
            Assert.AreEqual(data[1].Value, results[0].Value);
            Assert.AreEqual(data[1].SensorId, results[0].SensorId);
            Assert.AreEqual(data[0].CreatedOn, results[1].CreatedOn);
            Assert.AreEqual(data[0].Value, results[1].Value);
            Assert.AreEqual(data[0].SensorId, results[1].SensorId);
            Assert.AreEqual(data[7].CreatedOn, results[2].CreatedOn);
            Assert.AreEqual(data[7].Value, results[2].Value);
            Assert.AreEqual(data[7].SensorId, results[2].SensorId);
            Assert.AreEqual(data[6].CreatedOn, results[3].CreatedOn);
            Assert.AreEqual(data[6].Value, results[3].Value);
            Assert.AreEqual(data[6].SensorId, results[3].SensorId);
            Assert.AreEqual(data[13].CreatedOn, results[4].CreatedOn);
            Assert.AreEqual(data[13].Value, results[4].Value);
            Assert.AreEqual(data[13].SensorId, results[4].SensorId);
            Assert.AreEqual(data[12].CreatedOn, results[5].CreatedOn);
            Assert.AreEqual(data[12].Value, results[5].Value);
            Assert.AreEqual(data[12].SensorId, results[5].SensorId);
        }
    }
