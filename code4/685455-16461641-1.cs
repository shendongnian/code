    Process[] processes;
    Process selectedProc = null;
    int selectedProcId = 0;
    
    //  http://wutils.com/wmi/
    //  using System.Management;
    ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Process "
                                      + "WHERE Name = 'java.exe'");
    ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection queryCollection = searcher.Get();
    
    foreach (ManagementObject m in queryCollection)
    {
            // access properties of the WMI object
            Console.WriteLine("CommandLine : {0}", m["CommandLine"]);
            Console.WriteLine("ProcessId : {0}", m["ProcessId"]);
    
            if (m["CommandLine"].ToString().Contains("my pattern"))
            {
                selectedProcId = int.Parse(m["ProcessId"].ToString());
                selectedProc = Process.GetProcessById(selectedProcId);
                break;
            }
    }
    
    if (selectedProc != null)
    {
            Console.WriteLine("Proc title {0}", selectedProc.MainWindowTitle);
    }
