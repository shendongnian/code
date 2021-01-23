    [Test]
    public void Should_write_settings_to_store()
    {
        // Arrange
        var manager = new SettingsManager();
      
        // Act
        var settings = new Settings { SettingOne = "value", SettingsTwo = true };
        manager.WriteSettings(settings, @"C:\settings\settings.config");
    
        // Assert
        Assert.That(File.Exists(@"C:\settings\settings.config", Is.True));
    }
