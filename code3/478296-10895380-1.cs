    private bool RulesMatch(RuleViewModel actual, RuleViewModel expected)
	{
	    return actual.Property1 == expected.Property1
		    && actual.Name == expected.Name
			&& actual.Description == expected.Description;
	}
	
	Assert.That(results, Has.Some.Matches<RuleViewModel>(v => RulesMatch(v, _rule)));
