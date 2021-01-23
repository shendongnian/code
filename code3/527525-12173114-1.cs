    Assert.That(found, Has.All.Matches<Foo>(f => IsInExpected(f, expected)));
	
	private bool IsInExpected(Foo item, IEnumerable<Foo> expected)
	{
		var matchedItem = expected.FirstOrDefault(f => 
			f.Bar1 == item.Bar1 &&
			f.Bar2 == item.Bar2 &&
			f.Bar3 == item.Bar3
		);
		
	    return matchedItem != null;
	}
	
