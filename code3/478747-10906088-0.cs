    [Test]
    public void CalculateCost_ReturnsCorrectCost()
    {
        const int CorrectExpectedCost = 9;
        var truckShipping = new TruckShipping();
        
        var actualCost = truckShipping.CalculateCost();
 
        Assert.That(actualCost, Is.EqualTo(CorrectExpectedCost));
    }
