    private TemplateViewModel _templateViewModel;
    private ITemplateDataProvider _mock2;
    private IMappingEngine _mock2;
    private TemplateController _controller;
    private ActionResult _result;
    [Setup]
    public void Setup(){
        // ARRANGE
        _templateViewModel = new TemplateViewModel { Name = "MyTest" };
        _mock1 = new Mock<ITemplateDataProvider>();
        _mock2 = new Mock<IMappingEngine>();
        _controller = new TemplateController(_mock1.Object, _mock2.Object);
        _mock1.Setup(m => m.TemplateExists("MyTest")).Returns(true);
        // Set ModelState.IsValid to false
        _controller.ModelState.AddModelError("Name", 
                                            "This name already exists.");
        _result = controller.Create(_templateViewModel);
    }
    [Test]
    public void Create_TemplateAlreadyExists_ModelStateIsInvalid()
    {
        Assert.IsFalse(_controller.ModelState.IsValid);
    }
    [Test]
    public void Create_TemplateAlreadyExists_ResultIsPartialViewResult()
    {
        Assert.IsInstanceOfType(typeof(PartialViewResult), _result);
    }
    [Test]
    public void Create_TemplateAlreadyExists_ResultModelMatchesTemplateModel()
    {
        Assert.AreEqual(_templateViewModel, ((PartialViewResult)_result).Model);
    }
