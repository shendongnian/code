    // Act
    ActionResult result = controller.SaveAndExit(viewModel);
            
    // Assert
    Assert.IsInstanceOfType(result, typeof(ViewResult));
    ViewResult viewResult = (ViewResult)result;
           
    Assert.IsInstanceOfType(viewResult.Model, typeof(ViewModel1));
    ViewModel1 model = (ViewModel1)viewResult.Model;
    Assert.IsNotNull(model.Reg);
