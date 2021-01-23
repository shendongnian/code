    using System;
    
    namespace Draft
    {
        class Program
        {
            static void Main()
            {
                const string str = "Device2";
                var strParsed = (Devices)Enum.Parse(typeof(Devices), str);
    
                switch (strParsed) {
                    case Devices.Device1:
                        Console.WriteLine("Device 1");
                        break;
                    case Devices.Device2:
                        Console.WriteLine("Device 2");
                        break;
                    case Devices.Device3:
                        Console.WriteLine("Device 3");
                        break;
                    case Devices.Device4:
                        Console.WriteLine("Device 4");
                        break;
                }
    
                Console.ReadKey();
            }
    
            public enum Devices {
                Device1,
                Device2,
                Device3,
                Device4
            }
        }
    }
