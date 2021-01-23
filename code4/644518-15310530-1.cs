    namespace DeviceCreation
    {
        //public enum DeviceType { DeviceA, DeviceB, DeviceC, DeviceD };
        public abstract class Device
        {
            public string Identifier { get; private set; }
            public Device(string identifier)
            {
                Identifier = identifier;
            }
    
            public abstract string Name();
    
            public virtual void Close()
            {
    
            }
    
            public string AskIdentifier()
            {
                return Identifier;   
            }
    
            public static string GetIdentifierPattern()
            {
                return "xyzsdfsdf";
            }
        }
    
        public class DeviceA : Device
        {
            public DeviceA(string identifier) : base(identifier) { }
            public override string Name()
            {
                return "DeviceA";
            }        
        }
    
        public class DeviceB : Device
        {
            public DeviceB(string identifier) : base(identifier) { }
            public override string Name()
            {
                return "DeviceB";
            }       
    
        }
    
        public class DeviceC : Device
        {
            public DeviceC(string identifier) : base(identifier) { }
            public override string Name()
            {
                return "DeviceC";
            }        
        }
    
        public class DeviceD : Device
        {
            public DeviceD(string identifier) : base(identifier) { }
            public override string Name()
            {
                return "DeviceD";
            }        
        }
    
        public class DeviceFactory
        {
            private static List<Type> device_table = new List<Type>() { typeof(DeviceA), typeof(DeviceB), typeof(DeviceC), typeof(DeviceD) };
    
            public static Device Create(Device device, string identifier)
            {
                if (!device_table.Contains(device.GetType()))
                {
                    var message = string.Format("No device driver implemented for identifier {0}.", identifier);
                    throw new NotImplementedException(message);
                }
    
                if (string.IsNullOrEmpty(identifier))
                    throw new ArgumentException("No identifier selected.");
    
                //Try to open a device and then read identifier
                string dev_identifier;
                try
                {
                    var dev = DevIOLib.Open(identifier);
                    dev_identifier = dev.AskIdentifier();
                    dev.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error opening device {0} on {1}.", device, identifier));
                }
    
                var match = Regex.Match(dev_identifier, Device.GetIdentifierPattern());
                if (match.Success)
                {
                    var newDevice = (Device) Activator.CreateInstance(device.GetType(), dev_identifier);
                    return newDevice;
                }
                else
                    throw new Exception(string.Format("Wrong device connected to identifier {0}.", identifier));
            }
        }
    
        public static class DevIOLib
        {
            public static Device Open(string identier)
            {
                return new DeviceA(identier);
            }
        }
    
        public class DeviceCreationTest
        {
            public static void Main(string[] args)
            {
                var d = new DeviceA("asdfsdf");
                DeviceFactory.Create(d, "asdfsdf");
    
                Console.ReadKey();
                
            }   
        }
    }
