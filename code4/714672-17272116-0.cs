    // ARRANGE
    ModelMetadataProviders.Current = new DataAnnotationsModelMetadataProvider();
    var helper = MvcMocks.CreateHtmlHelper<TestModel>(true, true);
    helper.ViewContext.ViewData.Model = new TestModel { Field = null };
    helper.ViewContext.ViewData.ModelState.AddModelError("Field", "The field must be assigned.");
    // ACT
    var controlGroup = helper.ControlGroupFor(m => m.Field, CssClasses.IconUser).ToHtmlString();
