    interface IDevice
    {
        void Run();
    }
    interface IDeviceOperator
    {
        void Operate();
    }
    class DeviceOperator : IDeviceOperator 
    {
        private readonly IDevice _device;
        public DeviceOperator(IDevice device)
        {
            _device = device;
        }
        public void Operate()
        {
            _device.Run();
            // test other stuff here
        }
    }
    [TestFixture]
    public class DeviceOperatorTests
    {
        [Test]
        public void Test_DeviceOperator_Operate()
        {
            IDevice device = A.Fake<IDevice>(); // Using FakeItEasy 3rd party mocking framework syntax
            DeviceOperator deviceOperator = new DeviceOperator(device);
            deviceOperator.Operate();
        }
    }
