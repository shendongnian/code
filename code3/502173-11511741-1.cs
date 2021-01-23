    saveThemeAS.Verify(service => service.Execute(FakeUserID, It.Is<LayoutENT.Theme>(savedTheme => 
       {
          Assert.IsNotNull(savedTheme);
          Assert.AreEqual(FakeCopiedThemeName, savedTheme.Name);
          Assert.AreEqual(0, savedTheme.ThemeID)
          etc...
          return true;     
       }
    )));
