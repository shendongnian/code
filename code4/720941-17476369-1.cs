    public class GivenAnExceptionEmailer ( ) {
        [Fact]
        public void WhenYourSpecificActionHappens ( ) {
            
            var emailer = new Mock<IExceptionEmailer>();
            // ARRANGE the rest of your system here
            var target = new YourClassThatCatchesExceptions( emailer.Object );
            // do whatever ACTions needed here to make it throw
            target.Whatever( );
            // then ASSERT that the emailer was given correct type
            // this will fail if the exception wasn't thrown or wasn't
            // properly caught and handled.
            emailer.Verify ( e => 
                e.HandleYourExceptionTypeA ( It.IsAny<ExceptionTypeA>( )),
                Times.Once( )
            );
        }    
    }
