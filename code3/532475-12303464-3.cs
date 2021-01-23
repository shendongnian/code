    using Funq;
    using NUnit.Framework;
    
    namespace FunqIoCyclicReferenceTest
    {
        [TestFixture]
        public class FunqIoCCyclicReferenceTest
        {
            [Test]
            public void Please_Work()
            {
                var container = new Container();
                container.Register<IBar>(c => new Bar());
                container.Register<IFoo>(c => new Foo(c.Resolve<IBar>()));
    
                var foo = container.Resolve<IFoo>();
                
                Assert.IsNotNull(foo);
            }
        }
    
        public class Foo : IFoo
        {
            public Foo(IBar bar)
            {
                bar.Foo = this;
                Bar = bar;
            }
    
            public IBar Bar { get; set; }
        }
    
        public interface IBar
        {
            IFoo Foo { get; set; }
        }
    
        public interface IFoo
        {
            IBar Bar { get; set; }
        }
    
        public class Bar : IBar
        {
            public IFoo Foo { get; set; }
        }
    }
