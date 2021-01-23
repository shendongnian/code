    using System.Management;
    
    namespace ConsoleApplication1
    {
        class Program
        {
     
    
       static void Main(string[] args)
        {
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                Console.WriteLine("Username : {0}", envVar["Name"]);
            }
    
            Console.ReadLine();
    
        }
     
