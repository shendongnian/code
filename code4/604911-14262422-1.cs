    public class PhotoTest{
        public testFunctionCall(){
        var mockPicturesCreation = new Mock<IPicturesCreation>();
        new Photo(mockPicturesCreation.Object).CreatePhotos("blah");
        mockPicturesCreation.Verify(x => x.CreateIcons(.....), Times.Once);
        }
    }
