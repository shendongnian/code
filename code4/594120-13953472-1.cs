    [Given(@"I have a MyObject object as")]
    public void GivenIHaveAMyObjectObjectAs(Table table)
    {
       _myMock = new Mock<MyObject>();
       //you need to do all the setup before passing _myMock to table.CreateInstance
       _myMock.Setup(o => o.SomeProperty).Returns("someValue"); 
       var obj = table.CreateInstance<MyObject>(() => _myMock.Object);
       
       _myMock.VerifySet(foo => foo.Title = "The Title");
    }
