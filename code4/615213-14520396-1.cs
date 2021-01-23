    [Test]
    public void AfterOperationCursorIsArrow()
    {
        string lastMethod = null;
        Cursor lastCursor = null;
    
        var mock = new Mock<IMouseTraits>();
        mock.Setup(m => m.ForceCursor(It.IsAny<Cursor>()))
            .Callback((Cursor c) => lastMethod = "ForceCursor");
        mock.Setup(m => m.SetCursor(It.IsAny<Cursor>()))
            .Callback((Cursor c) => { 
                lastMethod = "SetCursor";
                lastCursor = c; 
            });
    
        var w = new WindowOperation(mock.Object);
        w.Execute();
    
         Assert.That(lastMethod, Is.EqualTo("SetCursor"));
         Assert.That(lastCursor, Is.EqualTo(Cursors.Arrow));
    }
