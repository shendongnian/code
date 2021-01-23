    [TestClass]
    public class ComparingTimespans {
        [TestMethod]
        public void CompareTimeBandTwoListsAreSameUsingCollectionAssert() {
	var lhs = new List<TimeBand>
	{
	    new TimeBand { StartTime = new TimeSpan(1,1,1) , EndTime = new TimeSpan(2,2,2)},
              new TimeBand { StartTime = new TimeSpan(3,3,3) , EndTime = new TimeSpan(4,4,4)},
          };
	var rhs = new List<TimeBand>
	{
	    new TimeBand { StartTime = new TimeSpan(1,1,1) , EndTime = new TimeSpan(2,2,2)},
	    new TimeBand { StartTime = new TimeSpan(3,3,3) , EndTime = new TimeSpan(4,4,4)},
          };
	CollectionAssert.AreEqual(lhs, rhs, new TimeBandComparer());
    }
    [TestMethod]
    public void CompareTimeBandTwoListsAreSameUsingSequenceEquals() {
        var lhs = new List<TimeBand>
        {
	new TimeBand { StartTime = new TimeSpan(1,1,1) , EndTime = new TimeSpan(2,2,2)},
	new TimeBand { StartTime = new TimeSpan(3,3,3) , EndTime = new TimeSpan(4,4,4)},
        };
        var rhs = new List<TimeBand>
        {
	 new TimeBand { StartTime = new TimeSpan(1,1,1) , EndTime = new TimeSpan(2,2,2)},
	 new TimeBand { StartTime = new TimeSpan(3,3,3) , EndTime = new TimeSpan(4,4,4)},
        };
        Assert.IsTrue(lhs.SequenceEqual(rhs, new TimebandEqualityComparer()));
    }
    private class TimeBand {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
    private class TimeBandComparer : IComparer {
       public int Compare(object x, object y) {
	var xTb = x as TimeBand;
	var yTb = y as TimeBand;
	return (xTb.StartTime == yTb.StartTime && xTb.EndTime == yTb.EndTime)
	         ? 0
	         : -1;
       }
    }
    private class TimebandEqualityComparer : IEqualityComparer<TimeBand> {
        public bool Equals(TimeBand x, TimeBand y) {
	return x.StartTime == y.StartTime && x.EndTime == y.EndTime;
        }
        
        public int GetHashCode(TimeBand obj) {
	return obj.StartTime.GetHashCode() ^ obj.EndTime.GetHashCode();
        }
    }
		
}
