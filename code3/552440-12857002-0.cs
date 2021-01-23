    var bar = A.Fake<IBar>();
    var foo = new Foo(bar);
	var expectedNumValues = new [] { 1, 2 };
	var actualNumValues = new List<int>();
	// Whenever a call to IBar.Test is made, store DTO.Num in list
	A.CallTo(() => bar.Test(A<DTO>.Ignored)).Invokes(
	    fakeCall =>
		{
		    var dto = (DTO) fakeCall.Arguments[0];
			numValues.Add(dto.Num);
		}
	);
	
    foo.DoStuff();
	
	// this verifies that both collections contain same elements at same positions
	CollectionAssert.AreEqual(expectedNumValues, actualNumValues);
