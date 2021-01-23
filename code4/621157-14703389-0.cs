    string Command = @"cscript C:\Windows\System32\Printing_Admin_Scripts\en-US\prnmngr.vbs -t -p Test002";
    
    ManagemenConnectionOptions connOptions = new ConnectionOptions();
    connOptions.Impersonation = ImpersonationLevel.Impersonate;
    connOptions.EnablePrivileges = true;
    tScope manScope = new ManagementScope
    	(String.Format(@"\\{0}\ROOT\CIMV2", Parameters.FQDN), connOptions);
    manScope.Connect();
    
    ObjectGetOptions objectGetOptions = new ObjectGetOptions();
    ManagementPath managementPath = new ManagementPath("Win32_Process");
    ManagementClass processClass = new ManagementClass
    	(manScope, managementPath, objectGetOptions);
    ManagementBaseObject inParams = processClass.GetMethodParameters("Create");
    inParams["CommandLine"] = Command; 
    
    ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);
    Console.WriteLine("Creation of the process returned: " + outParams["returnValue"]);
    Console.WriteLine("Process ID: " + outParams["processId"]);
