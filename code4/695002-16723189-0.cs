    public abstract class HardwareConfigBase
    {
        protected int TimesToLoop;
        public byte[] Data = new byte[32 * 8]; //Size of UInt, but still works for 8bit byte
        public void MyLoopCode
        {
            for(int i = 0; i < TimesToLoop; i++)
            {
                //Do whatever
            }
        }
    }
    public class ByteHardwareConfig
    {
        public ByteHardwareConfig
        {
            TimesToLoop = 8;
        }
    }
    
    public class UIntHardwareConfig
    {
        public UIntHardwareConfig
        {
             TimesToLoop = 32;
        }
    }
    public void Main()
    {
        var myHardwareConfig = new ByteHardwareConfig(); //Could also be UInt
        //Do some more initialization and fill the Data property.
        myHardwareConfig.MyLoopCode();
    }
