    using System;
    using System.Reactive.Subjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s0 = new BehaviorSubject<bool>(false);
            var s1 = new BehaviorSubject<bool>(false);
            bool l = false;
            var c = new BoolObservableConcetrator();
            var r0 = c.RegisterSource(s0);
            var r1 = c.RegisterSource(s1);
            var s = c.Subscribe(v => l = v);
            Assert.AreEqual(false, l);
            s0.OnNext(true);
            Assert.AreEqual(false, l);
            s1.OnNext(true);
            Assert.AreEqual(true, l);
            s0.OnNext(false);
            Assert.AreEqual(false, l);
            // Removing one of the message sources should update the result
            r0.Dispose();
            Assert.AreEqual(true, l);
        }
    }
