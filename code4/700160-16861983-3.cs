        public class AFactory : IAFactory
        {
            public IA Create() { ... }
        }
        public class B : IB
        {
            private readonly IAfactory factory;
            
            public B(IAFactory factory)
            {
                this.factory = factory;
            }
            
            public void Func()
            {
                IA a = factory.Create();
                //... use this.a ...
            }
        }
        [Test]
        public void Func_AHasValue1_DoesAction1()
        {
            Mock<IAFactory> mockFactory = new Mock<IAFactory>();
            Mock<IA> mock = new Mock<IA>();
            mockFactory.Setup(f => f.Create()).Returns(mock.Object);
            mock.Setup(a => a.somevalue).Returns("something");
            
            B sut = new B(mockFactory.Object);
            sut.Func();
            
            mock.Verify(m => m.SomethingHappenedToMe());
        }
