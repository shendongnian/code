    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    
    namespace WMIIRQ
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach(ManagementObject Memory in new ManagementObjectSearcher(
                    "select * from Win32_DeviceMemoryAddress").Get())
                {
    
                    Console.WriteLine("Address=" + Memory["Name"]);
                    // associate Memory addresses  with Pnp Devices
                    foreach(ManagementObject Pnp in new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DeviceMemoryAddress.StartingAddress='" + Memory["StartingAddress"] + "'} WHERE RESULTCLASS  = Win32_PnPEntity").Get())
                    {
                        Console.WriteLine("  Pnp Device =" + Pnp["Caption"]);
    
                        // associate Pnp Devices with IRQ
                        foreach(ManagementObject IRQ in new ManagementObjectSearcher(
                            "ASSOCIATORS OF {Win32_PnPEntity.DeviceID='" + Pnp["PNPDeviceID"] + "'} WHERE RESULTCLASS  = Win32_IRQResource").Get())
                        {
                            Console.WriteLine("    IRQ=" + IRQ["Name"]);
                        }
                    }
    
                }
                Console.ReadLine();
            }
        }
    }
