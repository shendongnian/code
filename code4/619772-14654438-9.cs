    [Test(Description = "Test If can successfully add application")]
    public void CanAddApplicationIfEligible()
    {
        var repo = GetRepo();
        var appService = new ApplicationService(repo);       
        var testAppDto = new ApplicationDto() { Id = 155, Name = "My Name" };
        
        var currentItems = repo.ApplicationDtos.Count();
        appService.Add(testAppDto);
        Assert.AreEqual(currentItems + 1, repo.ApplicationDtos.Count());
        var justAdded = repo.ApplicationsDto.Where(x=> x.Id = 155).FirstOrDefault();
        Assert.IsNotNull(justAdded);
        ///....
    }
    private static IEntityFrameworkRepo GetRepo{
        /create a mock repository
        var listRepo = new List<ApplicationDto>{
                             new ApplicationDto {Id=1, Name="MyName"}               
                       };
        var repo = new Mock<IEntityFrameworkRepo>();
        // setup the methods you know you will need for testing
        // returns initialzed list instead of DB queryable like in real impl.
        repo.Setup(x => x.ApplicationDtos)
            .Returns<IQueryable<ApplicationDto>>(x=> listRepo);
        
        // adds an instance of ApplicationDto to list
        repo.Setup(x => x.Add(It.IsAny<ApplicationDto>())
            .Callback<ApplicationDto>(a=> listRepo.Add(a));
        return repo.Object;
    }
