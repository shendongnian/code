    [Test]
    public void ComparerIgnoreOrderSimpleArraysTest()
    {
    	var a = new String[] { "A", "E", "F" };
    	var b = new String[] { "A", "c", "d", "F" };
    
    	var comparer = new CompareLogic();
    	comparer.Config.IgnoreCollectionOrder = true;
    	comparer.Config.MaxDifferences = int.MaxValue;
    
    	ComparisonResult result = comparer.Compare(a, b);
    	Console.WriteLine(result.DifferencesString);
    	Assert.IsTrue(result.Differences.Where(d => d.Object1Value == "E").Count() == 1);
    	Assert.IsTrue(result.Differences.Where(d => d.Object2Value == "c").Count() == 1);
    	Assert.IsTrue(result.Differences.Where(d => d.Object2Value == "d").Count() == 1);
    
    }
