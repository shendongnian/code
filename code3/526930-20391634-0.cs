	[TestMethod]
	public void FormatsAsDecimal()
	{
		var oneSeventh = new Rational(1, 7);
		var oneSeventhAsDecimal = oneSeventh.ToString(EApproxmationType.DecimalPlaces, 28, true);
		oneSeventhAsDecimal.Should().Be("0.1428571428571428571428571428");
	}
