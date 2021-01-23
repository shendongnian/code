     class Program
        {
            static void Main(string[] args)
            {
                System.Management.ManagementClass objClass = new System.Management.ManagementClass("Win32_Share");
                foreach(System.Management.ManagementObject objShare in objClass.GetInstances())
                {
                    Console.WriteLine(String.Format("{0} -> {1}",
                        objShare.Properties["Name"].Value, objShare.Properties["Path"].Value));
                }
            }
        }
