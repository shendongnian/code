    [TearDown]
    public void Cleanup()
    {
        Hotkeys.UnregisterAllLocals();
        Hotkeys.UnregisterAllGlobals();
    }
    
    [Test]
    public void IsRegisteredGlobal_InputNormalization()
    {
        Hotkeys.RegisterGlobal("Ctrl+Alt+P", delegate { });
        Assert.IsTrue(Hotkeys.IsRegisteredGlobal("Alt+P+Ctrl"),     "order independent");
        Assert.IsTrue(Hotkeys.IsRegisteredGlobal("ctrl+alt+p"),     "case insensitive");
        Assert.IsTrue(Hotkeys.IsRegisteredGlobal("Ctrl + Alt + P"), "whitespace independent");
    }
