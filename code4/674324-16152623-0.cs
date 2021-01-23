    public class Program
    {
        public static void Main()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_PnPSignedDriver");
    
            ManagementObjectCollection objCollection = objSearcher.Get();
    
            foreach (ManagementObject obj in objCollection)
            {
                string info = String.Format("Device='{0}',Manufacturer='{1}',DriverVersion='{2}' ", obj["DeviceName"], obj["Manufacturer"], obj["DriverVersion"]);
                Console.Out.WriteLine(info);
            }
    
            Console.Write("\n\nAny key...");
            Console.ReadKey();
        }
    }
