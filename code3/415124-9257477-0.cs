                        COMAddIns comAddIns = application.COMAddIns;
                    COMAddIn addIn = null;
                    foreach (COMAddIn addin in comAddIns)
                    {
                        string.Equals(addin.Description, "Your Addin Name", StringComparison.OrdinalIgnoreCase))
                        {
                            addIn = addin;                           
                            break;
                        }
                    }
                    if (addIn != null)
                    {
                        Console.WriteLine("Reloading....");
                        addIn.Connect = false;
                        addIn.Connect = true;
                        Console.WriteLine("Reloading complete!");
                    }
