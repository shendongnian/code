    [Test]
        public void DoSomething_WhenCalled_EventFired()
        {
             var mock = new Moq.Mock<IFileSystem>();
             bool isHit = false;
    
             mock.EventHit += (s, e) =>
             {
                isHit = true;
             };
    
             MyClass plugin = new MyClass (mock.Object);
    
             mock.Object.DoSomething();
    
             mock.Raise(x => x.EventHit += null, new EventArgs());
    
             Assert.IsTrue(isHit);
    
        }
