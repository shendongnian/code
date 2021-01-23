        [TestClass]
        public class GivenAValidRequestAndRepository(){
          [TestMethod]
          public void WhenWeReceiveAPostRequest(){
            //Arrange / Given
            var repository = new Mock<IRepository>();
            var request = new Mock<IRequest>();
            request.Setup ( rq => rq.ToString() )
                   .Returns ( "This is valid json ;-)" );
            request.Setup ( rq => rq.Days )
                   .Returns ( new List<IDay> {
                     "Monday",
                     "Tuesday",
                    } );
           var controller = new RequestController( repository.Object );
           //Act / When
           int actual = controller.Post( request.Object );
           //Assert / Verify
           // - then we add the request to the repository
           repository.Verify( 
             repo => repo.AddRequest( request, Times.Once() );
           // - then we add the two days (from above setup) in the request to the repository
           repository.Verify( 
             repo => repo.AddRequestDays( It.IsAny<IDay>(), Times.Exactly( 2 ));
           // - then we receive a count indicating we successfully processed the request
           Assert.NotEqual( -1, actual );
          }
        }
