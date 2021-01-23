    var problems = new List<Problems>();
    var problem = ProblemFactory.GenerateRandom();
    problems.Add(problem);
    var repository = new MemoryRepositoryService(); //or XmlRepositoryService
    repository.Submit(problems);
