    [Test]
	public void StackOverflow()
	{
		Regex pattern = new Regex(@"^.{4}[2-7](_\d{3}){2}(\[[^\]]+\])?(_\d{1,3})?(#\d{1,3})?\.png$");
		Assert.IsTrue(pattern.IsMatch("File1_000_000.png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000_1.png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000#2.png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000_1#2.png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000[text].png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000[text]_1.png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000[text]#2.png"));
		Assert.IsTrue(pattern.IsMatch("File1_000_000[text]_1#2.png"));
		Assert.IsFalse(pattern.IsMatch("File1_000_000[text]_#2.png"));
	}
