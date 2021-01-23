	[Fact]
    public void ThreadIdTest() {
        compassLogData.ThreadId = "[11]";
		var previousValue = compassLogData.ThreadId; // Question: how is this object set?
		bool propertyWasUpdated = false;
		compassLogData.PropertyChanged += (s, e) => {
			if (e.PropertyName == "ThreadId") {
				propertyWasUpdated = true;
			}
		};
		
		const string expected = "[12]";
		compassLogData.ThreadId = expected;
		string actual = compassLogData.ThreadId;
		
		Assert.Equal(expected, actual);
		ASsert.IsTrue(propertyWasUpdated);
	}
