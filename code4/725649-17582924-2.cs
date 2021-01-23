    [TestMethod]
    [ExepctedException(typeof(ArgumentException)]
    public void SUT_WhenInputIsBad_ThrowsArgumentException()
    {
        var sut = new MyClass(null,null); //don't care about our dependencies for this check
        sut.GetProjectBySpec(0,0,0); //or whatever is invalid input for you.
        //don't care about the return, only that the method throws.
    }
        
    
    [TestMethod]
    public void SUT_WhenInputIsGood_CreatesProjectCrewsByProjectSpec()
    {
      //create dependencies using Moq framework.
      var pf= new Mock<IProjectCrewsByProjectSpecFactory>();
      var repo = new Mock<IRepository<ProjectDgaCrew>>();
      //setup such that a call to pfactory.Create in the tested method will return nothing
      //because we actually don't care about the result - only that the Create method is called.
      pf.Setup(p=>p.Create(1,2,3)).Returns<ProjectDgaCrew>(new ProjectDgaCrew());
      //setup the repo such that any call to GetList with any ProjectDgaCrew object returns an empty list
    //again we do not care about the result. 
    //This mock dependency is only being used here
    //to stop an exception being thrown from the test method
    //you might want to refactor your behaviours
    //to specify an early exit from the function when the factory returns a null object for example.
       repo.Setup(r=>r.GetList(It.IsAny<ProjectDgaCrew>()).Returns<IList<ProjectDGACrew>>(new List<ProjectDgaCrew>());
      //create our System under test, inject our mock objects:
       var sut = new MyClass(repo,pf.Object);
       //call the method:
       sut.GetProjectBySpec(1,2,3);
       //and verify that it did indeed call the factory.Create method.
        pf.Verify(p=>p.Create(1,2,3),"pf.Create was not called with 1,2,3");              
    }
            public void SUT_WhenInputIsGood_CallsRepoGetList(){} //you get the idea
            public void SUT_WhenInputIsGood_ReturnsNonNullDataSourceResult(){}//and so on.
