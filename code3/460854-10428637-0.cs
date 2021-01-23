    using System;
    using System.Threading.Tasks;
    using Windows.Devices.Enumeration;
    using Windows.Foundation;
    
    class App {
        static void Main() {
            EnumDevices().Wait();
        }
    
        private static async Task EnumDevices() {
            // To call DeviceInformation.FindAllAsync:
            // Reference Windows.Devices.Enumeration.winmd when building
            // Add the "using Windows.Devices.Enumeration;" directive (as shown above)
            foreach (DeviceInformation di in await DeviceInformation.FindAllAsync()) {
                Console.WriteLine(di.Name);
            }
        }
    }
