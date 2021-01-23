        [Test]
        public void TestMethod()
        {
            var testerStub = new TesterStub();
            testerStub.ProcessVehicles();
            //Assert something here
        }
        public class TesterStub : Tester
        {
            public override IObject DetermineVehicleType(CarObject obj)
            {
                var mockObject = new Mock<IObject>();
                mockObject.Setup(x => x.SomeMethod).Returns(Something);
                return mockObject.Object;
            }
        }
        public class Tester
        {
            protected virtual IObject DetermineVehicleType(CarObject obj)
            {
                return new ObjectTester();
            }
            public void ProcessVehicles()
            {
                var carType = DetermineVehicleType(new CarObject());
            }
        }
        public class ObjectTester : IObject
        {
        }
        public interface IObject
        {
        }
        public class CarObject
        {
        }
