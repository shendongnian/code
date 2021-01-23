    [Theory]
    [InlineData("nl-NL", "Terugbelverzoek")]
    [InlineData("en-US", "Callback")]
    public void TestTranslationOfDescriptionAttribute(string culture, string expectedValue)
    {
        // Arrange
        CultureInfo cultureInfo = new CultureInfo(culture);
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    
        ContactOptionType contactOptionType = ContactOptionType.Callback;
    
        // Act
        string description = contactOptionType.GetDisplayDescription();
    
        // Assert
        Assert.Equal(expectedValue, description);
    }
