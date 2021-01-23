    using System;
    using Decorator;
    using Moq;
    using NUnit.Framework;
    
    namespace StackOverflow.Tests.HowToTest
    {
        [TestFixture]
        public class CachingDecoratorTest
        {
            [Test]
            public void Constructor()
            {
                Assert.Throws(typeof(ArgumentNullException), () => new CachingDecorator(null));
            }
    
            [Test]
            public void Apply_NotCached()
            {
                var internalBehaviorMock = new Mock<IModifyBehavior>();
                internalBehaviorMock.Setup(x => x.Apply(It.IsAny<string>())).Returns<string>(y => y);
                const string someText = "someText";
                var target = new CachingDecorator(internalBehaviorMock.Object);
                target.Apply(someText);
                internalBehaviorMock.Verify(x => x.Apply(It.IsAny<string>()), Times.Once());
            }
    
            [Test]
            public void Apply_Cached()
            {
                var internalBehaviorMock = new Mock<IModifyBehavior>();
                internalBehaviorMock.Setup(x => x.Apply(It.IsAny<string>())).Returns<string>(y => y);
                const string someOtherText = "someOtherText";
                var target = new CachingDecorator(internalBehaviorMock.Object);
                target.Apply(someOtherText);
                target.Apply(someOtherText);
                internalBehaviorMock.Verify(x => x.Apply(It.IsAny<string>()), Times.Once());
            }
        }
    }
