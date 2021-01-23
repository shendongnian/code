	[TestMethod]
	public void DoingInTheMiddle()
	{
		var status = new List<String>();
		var daysTillTest = Range.Create(4, 1).ToObservable();
		daysTillTest.Do(d => status.Add(d + "=" + (d == 1 ? "Study Like Mad" : ___)))
                    .Subscribe();
		Assert.AreEqual("[4=Party, 3=Party, 2=Party, 1=Study Like Mad]", status.AsString());
	}
