    [TearDown]
    public void Cleanup()
    {
        Hotkeys.UnregisterAllLocals();
        Hotkeys.UnregisterAllGlobals();
    }
    
    [Test]
    public void IsRegisteredGlobalInputNormalization()
    {
        Hotkeys.RegisterGlobal("Ctrl+Alt+P", delegate { });
        Assert.That(Hotkeys.IsRegisteredGlobal("Alt+P+Ctrl"), Is.True);
        Assert.That(Hotkeys.IsRegisteredGlobal("ctrl+alt+p"), Is.True);
        Assert.That(Hotkeys.IsRegisteredGlobal("Ctrl + Alt + P"), Is.True);
    }
