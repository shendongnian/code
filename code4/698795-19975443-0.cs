    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    namespace Rhino
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                var r = new Robot();
                var obstacleMock = MockRepository.GenerateMock<IObs>();
                obstacleMock.Expect(x => x.ditanceSq(Arg<Robot>.Is.Anything)).Return(5.5);
                //use this line to ensure correct Robot is used as parameter
                //obstacleMock.Expect(x => x.ditanceSq(Arg<Robot>.Is.Equal(r))).Return(5.5);
                var result = r.range(obstacleMock, 0.5);
                obstacleMock.VerifyAllExpectations();
                Assert.IsTrue(result);
            }
        }
        public class Robot
        {
            public virtual bool range(IObs ob, double range)
            {
                return  ob.ditanceSq(this) < range;			
            }
        }
        public interface IObs
        {
            double ditanceSq(Robot r);
        }
    }
