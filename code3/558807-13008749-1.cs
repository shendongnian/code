    public class Form
    {
        USBReader reader;
        CollectedData data;
        public Form()
    	{
            reader = new USBReader();
    	}
    
        public void ReadUSBData() 
        {
            data = reader.ReadUSBData();
        }
    }
    // Type F
    public class USBReader 
    {
        public CollectedData ReadUSBData() 
        { // usb read logic.
        }
    }
    
    //Type B
    public class CollectedData {
        List<A> list = new List<A>();   
    }
    
    public class A { }
