    public void Create()
    {
        var db = new Mock<IJournalsRepository>();
        db.Setup(m => m.FindJournal(7)).Returns(new Journal());
        var controller = new JournalsController(db.Object);
        controller.Create(7, "test");
        db.Verify(m => m.FindJournal(7), Times.Once());
        db.Verify(m => m.Add(It.IsAny<JournalEntry>()), Times.Once());
        db.Verify(m => m.SaveChanges(), Times.Once());
    }
