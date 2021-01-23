        public class A : IA { ... }
        public class B : IB
        {
            private readonly A a;
            
            public B(IA a)
            {
                this.a = a;
            }
            
            public void Func()
            {
                //... use this.a ...
            }
        }
        [Test]
        public void Func_AHasValue1_DoesAction1()
        {
            Mock<IA> mock = new Mock<IA>();
            mock.Setup(a => a.somevalue).Returns("something");
            
            B sut = new B(mock.Object);
            sut.Func();
            
            mock.Verify(m => m.SomethingHappenedToMe());
        }
