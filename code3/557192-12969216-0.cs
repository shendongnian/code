    using System;
    using System.Management;
    using System.Windows.Forms;
    
    namespace WMISample
    {
        public class CallWMIMethod
        {
            public static void Main()
            {
                try
                {
                    ManagementObject classInstance = 
                        new ManagementObject("root\\CIMV2", 
                        "Win32_Product.IdentifyingNumber='{EDDE41A3-A870-4D97-A1ED-67FF62AA0552}',Name='MyServiceSetup',Version='1.0.0'",
                        null);
    
                    // no method in-parameters to define
    
    
                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams = 
                        classInstance.InvokeMethod("Uninstall", null, null);
    
                    // List outParams
                    Console.WriteLine("Out parameters:");
                    Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
                }
                catch(ManagementException err)
                {
                    MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
                }
            }
        }
    }
