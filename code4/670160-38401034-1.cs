        private bool CreatePrinterPort()
        {
            if (CheckPrinterPort())
                return true;
            var printerPortClass = new ManagementClass(managementScope, new ManagementPath("Win32_TCPIPPrinterPort"), new ObjectGetOptions());
            printerPortClass.Get();
            var newPrinterPort = printerPortClass.CreateInstance();
            newPrinterPort.SetPropertyValue("Name", PrinterPortName);
            newPrinterPort.SetPropertyValue("Protocol", 1);
            newPrinterPort.SetPropertyValue("HostAddress", printerIP);
            newPrinterPort.SetPropertyValue("PortNumber", 9100);    // default=9100
            newPrinterPort.SetPropertyValue("SNMPEnabled", false);  // true?
            newPrinterPort.Put();
            return true;
        }
        private bool CreatePrinterDriver(string printerDriverFolderPath)
        {
            var endResult = false;
            // Inspired from https://msdn.microsoft.com/en-us/library/aa384771%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
            // and http://microsoft.public.win32.programmer.wmi.narkive.com/y5GB15iF/adding-printer-driver-using-system-management
            string printerDriverInfPath = IOUtils.FindInfFile(printerDriverFolderPath);
            var printerDriverClass = new ManagementClass(managementScope, new ManagementPath("Win32_PrinterDriver"), new ObjectGetOptions());            
            var printerDriver = printerDriverClass.CreateInstance();
            printerDriver.SetPropertyValue("Name", driverName);
            printerDriver.SetPropertyValue("FilePath", printerDriverFolderPath);
            printerDriver.SetPropertyValue("InfName", printerDriverInfPath);
            // Obtain in-parameters for the method
            using (ManagementBaseObject inParams = printerDriverClass.GetMethodParameters("AddPrinterDriver"))
            {
                inParams["DriverInfo"] = printerDriver;
                // Execute the method and obtain the return values.            
                using (ManagementBaseObject result = printerDriverClass.InvokeMethod("AddPrinterDriver", inParams, null))
                {
                    // result["ReturnValue"]
                    uint errorCode = (uint)result.Properties["ReturnValue"].Value;  // or directly result["ReturnValue"]
                    // https://msdn.microsoft.com/en-us/library/windows/desktop/ms681386(v=vs.85).aspx
                    switch (errorCode)
                    {
                        case 0:
                            //Trace.TraceInformation("Successfully connected printer.");
                            endResult = true;
                            break;
                        case 5:
                            Trace.TraceError("Access Denied.");
                            break;
                        case 123:
                            Trace.TraceError("The filename, directory name, or volume label syntax is incorrect.");
                            break;
                        case 1801:
                            Trace.TraceError("Invalid Printer Name.");
                            break;
                        case 1930:
                            Trace.TraceError("Incompatible Printer Driver.");
                            break;
                        case 3019:
                            Trace.TraceError("The specified printer driver was not found on the system and needs to be downloaded.");
                            break;
                    }
                }
            }
            return endResult;
        }
        private bool CreatePrinter()
        {
            var printerClass = new ManagementClass(managementScope, new ManagementPath("Win32_Printer"), new ObjectGetOptions());
            printerClass.Get();
            var printer = printerClass.CreateInstance();
            printer.SetPropertyValue("DriverName", driverName);
            printer.SetPropertyValue("PortName", PrinterPortName);
            printer.SetPropertyValue("Name", printerName);
            printer.SetPropertyValue("DeviceID", printerName);
            printer.SetPropertyValue("Location", "Front Office");
            printer.SetPropertyValue("Network", true);
            printer.SetPropertyValue("Shared", false);
            printer.Put();
            return true;
        }
        private void InstallPrinterWMI(string printerDriverPath)
        {
            bool printePortCreated = false, printeDriverCreated = false, printeCreated = false;
            try
            {                
                printePortCreated = CreatePrinterPort();
                printeDriverCreated = CreatePrinterDriver(printerDriverPath);
                printeCreated = CreatePrinter();
            }
            catch (ManagementException err)
            {
                if (printePortCreated)
                {
                    // RemovePort
                }
                Console.WriteLine("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }
