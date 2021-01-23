		[Test]
		public void TestStub()
		{
			var testItem = MockRepository.GenerateStub<ITest>();
			testItem.Stub(x => x.Something).Return("Hello");
			Assert.AreEqual("Hello", testItem.Something);
		}
