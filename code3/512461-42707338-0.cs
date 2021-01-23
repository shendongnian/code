     Task.Run(()=>{
         if (!IsPrinterOk(printerDocument.PrinterSettings.PrinterName,checkTimeInMillisec))
         {
            // failed printing, do something...
         }
        });
