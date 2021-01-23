    [TestMethod]
    public void VerifyCostIsCorrect()
    {
    	new TruckShipping()
            .CalculateCost()
            .Should("The TruckShipping implementation returns a wrong cost.").Be.EqualTo(9);
    }
