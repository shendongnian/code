    public void AddItemSetsOrderDateAsCurrentTime()
    {
        // Arrange
        var currentTime = new DateTime(2011, 1, 1, 12, 15);
        TimeProvider.CurrentTimeProvider = () => currentTime;
    
        // Act
        //...
    }
