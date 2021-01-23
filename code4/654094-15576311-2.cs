    [TestMethod]
    public void MergeListsTest()
    {
        // Arrange
        var list1 = new List<Object1>
                        {
                            new Object1(null, "1", "1"),
                            new Object1(null, "1", "2"),
                            new Object1(null, "1", "3"),
                            new Object1(new TimeSpan(0, 0, 30), "2", "5")
                        };
        var list2 = new List<Object1>
                        {
                            new Object1(new TimeSpan(0, 1, 20), "1", "1"),
                            new Object1(new TimeSpan(0, 0, 51), "1", "2"),
                        };
        var expected = new List<Object1>
                            {
                                new Object1(new TimeSpan(0, 1, 20), "1", "1"),
                                new Object1(new TimeSpan(0, 0, 51), "1", "2"),
                                new Object1(null, "1", "3"),
                                new Object1(new TimeSpan(0, 0, 30), "2", "5")
                            };
        // Act
        List<Object1> actual = MergeLists(list1, list2);
        // Assert
        // Note: need to order the actual result to use CollectionAssert.AreEqual()
        List<Object1> orderedActual = actual.OrderBy(o => string.Join(";", o.Parameters)).ToList();
        CollectionAssert.AreEqual(expected, orderedActual, new Object1Comparer());
    }
    public class Object1Comparer : IComparer, IComparer<Object1>
    {
        public int Compare(Object1 x, Object1 y)
        {
            if (x.Time == null && y.Time == null) return 0;
            if (x.Time == null || y.Time == null) return -1;
            int timeComparison = TimeSpan.Compare(x.Time.Value, y.Time.Value);
            if (timeComparison != 0) return timeComparison;
            if (x.Parameters == null && y.Parameters == null) return 0;
            if (x.Parameters == null || y.Parameters == null) return -1;
            if (x.Parameters.SequenceEqual(y.Parameters)) return 0;
            return -1;
        }
        public int Compare(object x, object y)
        {
            if (x is Object1 && y is Object1)
                return Compare(x as Object1, y as Object1);
            return -1;
        }
    }
