    public class SomeClassA
    {
        public void DoThisOnDevice(Device device)
        {
            device.DoSomeStuffOn(RegisterFactory.GetRegister(RegisterType.reg1), SomeCommonlyUsedStrategy);
        }
    }
