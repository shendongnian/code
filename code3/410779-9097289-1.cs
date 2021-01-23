    [TestMethod]
    public void TestChangeData()
    {
        IMyView view = MockRepository.DynamickMock<IMyView>();
        view.Stub(v => v.SomeData).PropertyBehavior();
    
        MyPresenter presenter = new MyPresenter(view);
    
        presenter.ChangeData();
    
        Assert.AreEqual("Some changed data", view.SomeData);
    }
