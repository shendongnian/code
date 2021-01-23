    [TestMethod]
    public void RefreshPrice_EmptyPriceIsNotUpDownIsNotChange_ReturnsInitalPrice()
    {
        //Arrange
        Legacy legacyUnderTest = new this.getLegacyUnderTest();
        bool isUpDown = false;
        bool isChange = false;
        string initialPrice = string.Empty;
        //Act
        string result = legacyUnderTest.RefreshPrice(initalPrice, isUpDown, isChange);
        //Assert
        Debug.IsEqual(initalPrice, result);
    }
