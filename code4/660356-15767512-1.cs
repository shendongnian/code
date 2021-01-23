	[Test]
	public void Test_OneItem()
	{
		var autoMocker = new RhinoAutoMocker<TestClass1>();
		autoMocker.Inject(MockRepository.GenerateMock<IItem>());
		Assert.AreEqual(1, autoMocker.ClassUnderTest.Items.Count());
	}
	[Test]
	public void Test_TwoItems()
	{
		var autoMocker = new RhinoAutoMocker<TestClass1>();
		autoMocker.Inject(MockRepository.GenerateMock<IItem>());
		autoMocker.Inject(MockRepository.GenerateMock<IItem>());
		Assert.AreEqual(2, autoMocker.ClassUnderTest.Items.Count());
	}
