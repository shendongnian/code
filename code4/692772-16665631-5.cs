    [TestMethod]
    public void TestDecreaseTutorArea()
    {
        HelpWith info = new HelpWith();
        info.Subcategories.Add(1);
        info.UserId = 14;
        TutorService tutorService = new TutorService();
        tutorService.DecreaseTutorArea(info);
    }
