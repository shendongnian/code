		[TestMethod]
		public void ChangeTrackingModelBase_BasicFunctionalityTest()
		{
			var person = new ChangeTrackingPerson();
			var eventAssert = new PropertyChangedEventAssert(person);
			Assert.IsNull(person.FirstName);
			Assert.AreEqual("", person.LastName);
			eventAssert.ExpectNothing();
			person.FirstName = "John";
			eventAssert.Expect("FirstName");
			eventAssert.Expect("IsChanged");
			eventAssert.Expect("FullName");
			person.LastName = "Doe";
			eventAssert.Expect("LastName");
			eventAssert.Expect("FullName");
			person.InvokeGoodPropertyMessage();
			eventAssert.Expect("FullName");
			person.InvokeAllPropertyMessage();
			eventAssert.Expect("");
		}
