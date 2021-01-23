    namespace DeviceCreation
    {
        public abstract class Device
        {
            public abstract string Name();
            public abstract string AskIdentifier();
    
            public string GetIdentifierPattern()
            {
                throw new NotImplementedException();
            }
        }
    
        public class DeviceA : Device
        {
            public override string Name()
            {
                return "DeviceA";
            }
    
            public override string AskIdentifier()
            {
                return "DeviceIdentierA";
            }
        }
    
        public class DeviceB : Device
        {
            public override string Name()
            {
                return "DeviceB";
            }
    
            public override string AskIdentifier()
            {
                return "DeviceIdentierB";
            }
    
        }
    
        public class DeviceC : Device
        {
            public override string Name()
            {
                return "DeviceC";
            }
    
            public override string AskIdentifier()
            {
                return "DeviceIdentierC";
            }
        }
    
        public class DeviceD : Device
        {
            public override string Name()
            {
                return "DeviceD";
            }
    
            public override string AskIdentifier()
            {
                return "DeviceIdentierD";
            }
        }
        
        public class DeviceFactory
        {
    	    private List<Device> device_table = new List<Device>() { new DeviceA(),new DeviceB(),new DeviceC(),new DeviceD()};
        	
    	    public Device Create(Device device,string identifier)
    	    {
    		    //Returns an open device for the given identifier. If there is no proper
    		    //driver it raises an NotImplementedError. If wrong device connected to
    		    //port a ValueError is raised
                //if (string.IsNullOrEmpty(identifier))
                if (!device_table.Contains(device))            
                {
                    var message = string.Format("No device driver implemented for identifier {0}.", identifier);
                    throw new NotImplementedException(message);
                }
    
                if (string.IsNullOrEmpty(identifier))
                    throw new Exception("No identifier selected.");
    
                //Try to open a device and then read identifier
    
                string dev_identifier;
    
                try{
                    var dev = DevIOLib.open(identifier);
                    dev_identifier = dev.AskIdentifier();
                    dev.close();
                }
                catch(Exception ex)
                {
                    throw new Exception(string.Format("Error opening device {0} on {1}.",device,identifier));
                }
    
                var match =  Regex.Match(dev_identifier,device.GetIdentifierPattern());
                if (match.Success)
                {
                    // return appropriate device object
                }
                else
                    throw new Exception(string.Format("Wrong device connected to identifier {0}.", identifier));
    	    }
        }
    }
