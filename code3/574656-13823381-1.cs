    Application word = new Application();
    word.DisplayAlerts = WdAlertLevel.wdAlertsNone;
    try
    {
        word.Documents.OpenNoRepairDialog(@"c:\testfolder\Doc2.docx", ReadOnly: true, PasswordDocument: "RandomButSurelyNotRightPassword");
        word.ActivePrinter = "TIFF Image Printer 10.0";
        Doc.PrintOut(); //printout untested for now
        Doc.Close(false);
    }
    catch (System.Runtime.InteropServices.COMException ex)
    {
        if (ex.ErrorCode == 0x12345678)
        {
            //skip file and log file name and position for review
        }
    }
