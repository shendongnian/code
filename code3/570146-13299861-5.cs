    var testControllerBuilder = new TestControllerBuilder(); // this is from MVC Contrib
    var controller = new MoviesController(
        this.GetMock<IMovieQueryManager>().Object);
    testControllerBuilder.InitializeController(controller); // this allows me to use the Session, Request and Response objects as mock objects, again this is provided by the MVC Contrib framework
    // I should be able to call something like this but this is not working due to some problems with DLL versions (hell DLL's) between MVC Controb, Moq and MVC itself
    // testControllerBuilder.CreateController<MoviesController>();
    controller.WithCallTo(x => x.Index(string.Empty)).ShouldRenderDefaultView(); // this is using Fluent MVC Testing
