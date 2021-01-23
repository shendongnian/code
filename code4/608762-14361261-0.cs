    using System;
    using System.Management;
    using System.Management.Instrumentation;
    namespace Test {
        class TestClass {
            [STAThread]
            static void Main(string[] args) {
                Console.WriteLine("Win32 SoundDevices\r\n===============================");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_SoundDevice");
                foreach (ManagementObject soundDevice in searcher.Get()) {
                    Console.WriteLine("Device found: {0}\n", soundDevice.ToString());
                }
                Console.WriteLine("Search complete.");
                Console.Read();
            }
        }
    }
