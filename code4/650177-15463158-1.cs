    [TestMethod]
    public void TestGetByName()
    {
        IProjectsRepository projectRepository = new ProjectsRepository();
    
        var expected = new Project { Id = 1000, Name = "Project1" };
        var actual = projectRepository.GetByName(expected.Name);
    
        Assert.AreEqual<Project>(expected, actual);
    }
