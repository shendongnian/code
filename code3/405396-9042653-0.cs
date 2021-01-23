    int numCalls = 0;
    List<Container> expectedContainers = new List<Container>();
    
    //Add list of expected containers here.  Since I want the first call to return null
    //and the 2nd call to return a valid container object I will fill the array with null
    //in the 1st entry and a valid container in the 2nd
    expectedContainers.Add(null);
    expectedContainers.Add(new Container());
    CntnrRepository.Setup<Container>(
                    repo => repo.Find(It.IsAny<Expression<Func<Container, bool>>>()))
                    .Returns(() => returnContainers[numCalls])
                    .Callback(() => numCalls++);
