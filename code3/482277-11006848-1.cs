    [TestMethod]
    public void CalculateCost() {
        //arrange
        var myProduct = new MyProduct();
        myProduct.Price = 1000;
        myProduct.Tax= 0.07;
       
        //act
        double actualCost = myProduct.CalculateCost();
        //assert
        double expectedCost = 1052;
        Assert.AreEqual(expectedCost, actualCost );
    }
