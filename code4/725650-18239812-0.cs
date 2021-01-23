    [TestClass]
        public class CrewControllerTest
        {
            [TestMethod]
            public void GetProjectCrewsBySpecTest()
            {
              // arrange
              const String ExpectedOutput = "";
              int projectId = 1;
              int seasonId = 2;
              int episodeId = 3;
    
              // act
              var crewController = new CrewController();
              var resultList= crewController.GetProjectCrewsBySpec(1, 2,3) as DataSourceResult;
              var someInsideData = resultlist.FirstOrDefault().GetType().GetProperty("PropertyName").GetValue(resultList.FirstOrDefault(),null);
    
              // assert
              Assert.AreEqual(someInsideData , ExpectedOutput);          
            }
    }
