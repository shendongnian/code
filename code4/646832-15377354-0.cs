    using System;
    using System.Linq;
    using Decorator;
    using NUnit.Framework;
    
    namespace StackOverflow.Tests.HowToTest
    {
        [TestFixture]
        public class ReverseBehaviorTest
        {
            [Test]
            public void Apply()
            {
                const string someText = "someText";
                var target = new ReverseBehavior();
                var result = target.Apply(someText);
                Assert.AreEqual(someText.Reverse(), result);
            }
            [Test]
            public void Apply_WhenNull()
            {
                var target = new ReverseBehavior();
                var result = target.Apply(null);
                Assert.AreEqual(String.Empty, result);
            }
        }
    }
