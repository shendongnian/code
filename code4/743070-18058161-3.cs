    this._directoryEntryMock = new Mock<IDirectoryEntry>();
    this._directoryEntryMock
            .Setup(m => m.Properties)
            .Returns(new Hashtable()
            {
                { "PasswordExpirationDate", SystemTime.Now().AddMinutes(-1) }
            });
