    protected static LayoutENT.Theme savedTheme;
    // Arrange
    themeParam = null;
    saveThemeAS.Setup(service => service.Execute(FakeUserID, It.Is<LayoutENT.Theme>)
        .Callback<layoutENT.Theme>(p =>  savedTheme = p);
    // Act
    // Calls the subject under test
    // Assert
    Assert.IsNotNull(savedTheme); 
    Assert.AreEqual(FakeCopiedThemeName, savedTheme.Name); 
    Assert.AreEqual(0, savedTheme.ThemeID) 
     
