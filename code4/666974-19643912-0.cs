         //1 - Add Printer Monitor
                LogHelper.Log("Adding Printer Monitor.");
                GenericResult printerMonitorResult = AddPrinterMonitor(monitorName);
                if (printerMonitorResult.Success == false)
                {
                    if (printerMonitorResult.Message.ToLower() != "the specified print monitor has already been installed")
                        throw printerMonitorResult.Exception;
                }
