    if (!UnsafeNativeMethods.PrintDlg(data))
                    return false;
 
                IntSecurity.AllPrintingAndUnmanagedCode.Assert();
                try { 
                    UpdatePrinterSettings(data.hDevMode, data.hDevNames, data.nCopies, data.Flags, settings, PageSettings); 
                }
                finally { 
                    CodeAccessPermission.RevertAssert();
                }
.
.
.
    // VSWhidbey 93449: Due to the nature of PRINTDLGEX vs PRINTDLG, separate but similar methods 
    // are required for updating the settings from the structure utilized by the dialog.
    // Take information from print dialog and put in PrinterSettings
    private static void UpdatePrinterSettings(IntPtr hDevMode, IntPtr hDevNames, short copies, int flags, PrinterSettings settings, PageSettings pageSettings) {
            // Mode 
            settings.SetHdevmode(hDevMode);
            settings.SetHdevnames(hDevNames); 
 
            if (pageSettings!= null)
                pageSettings.SetHdevmode(hDevMode); 
            //Check for Copies == 1 since we might get the Right number of Copies from hdevMode.dmCopies...
            //this is Native PrintDialogs
            if (settings.Copies == 1) 
                settings.Copies = copies;
 
            settings.PrintRange = (PrintRange) (flags & printRangeMask); 
        }
