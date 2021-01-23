                object[] oWordDialogParams = {PreferredPrinter.Name, true};
                object[] oWordDialogParamsWithPort = {string.Format("{0} on {1}", PreferredPrinter.Name, PreferredPrinter.PortName), true};
                string[] argNames = {"Printer", "DoNotSetAsSysDefault"};
    //oWord is my own class that provides a fairly simple wrapper around MS Word
                oWord.Application.ActivePrinter = UserSettings[SETTING_PREFERRED_PRINTER] as string;
                Dialog printDialog = oWord.Application.Dialogs[WdWordDialog.wdDialogFilePrintSetup];
                object wordBasic = oWord.Application.WordBasic;
                try {
                    wordBasic.GetType().InvokeMember("FilePrintSetup"
                        , BindingFlags.InvokeMethod
                        , null
                        , wordBasic
                        , oWordDialogParams
                        , null
                        , null
                        , argNames);
                }catch(Exception e) {
                    _s_logger.Info("Failed to print using printer name, trying printer name and port", e);
                    try {
                        wordBasic.GetType().InvokeMember("FilePrintSetup"
                            , BindingFlags.InvokeMethod
                            , null
                            , wordBasic
                            , oWordDialogParamsWithPort
                            , null
                            , null
                            , argNames);
                    }catch(Exception e2) {
                        _s_logger.Info("Failed to print using printer name and port", e2);
                        throw;
                    }
                }
