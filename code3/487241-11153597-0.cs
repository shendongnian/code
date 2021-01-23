      var query = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                    var printers = query.Get();                   
                    foreach (ManagementObject printer in printers)
                    {
                        if (printer["name"].ToString() == combox_pinter.SelectedItem.ToString())
                        {
                            printer.InvokeMethod("SetDefaultPrinter", new object[] { combox_pinter.SelectedItem.ToString() });
                        }
                    }
