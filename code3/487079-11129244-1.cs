    class DocWrapper
    {
      private const int _exceptionLimit = 4;
    
      // should be a singleton instance of wrapper for Word
      // the code below assumes this was set beforehand
      // (e.g. from another helper method)
      private static Microsoft.Office.Interop.Word._Application _app;
    
      public virtual void PrintToSpecificPrinter(string fileName, string printer)
      {
        // Sometimes Word fails, so needs to be restarted.
        // Sometimes it's not Word's fault.
        // Either way, having this in a retry-loop is more robust.
        for (int retry = 0; retry < _exceptionLimit; retry++)
        {
          if (TryOncePrintToSpecificPrinter(fileName, printer))
            break;
    
          if (retry == _exceptionLimit - 1) // this was our last chance
          {
            // if it didn't have actual exceptions, but was not able to change the printer, we should notify somebody:
            throw new Exception("Failed to change printer.");
          }
        }
      }
    
      private bool TryOncePrintToSpecificPrinter(string fileName, string printer)
      {
        Microsoft.Office.Interop.Word.Document doc = null;
    
        try
        {
          doc = OpenDocument(fileName);
    
          if (!SetActivePrinter(printer))
            continue;
    
          Print(doc);
    
          return true; // we did what we wanted to do here
        }
        catch (Exception e)
        {
          if (retry == _exceptionLimit)
          {
            throw new Exception("Word printing failed.", e);
          }
          // restart Word, remembering to keep an appropriate delay between Quit and Start.
          // this should really be handled by wrapper classes
        }
        finally
        {
          if (doc != null)
          {
            // release your doc (COM) object and do whatever other cleanup you need
          }
        }
    
        return false;
      }
    
      private void Print(Microsoft.Office.Interop.Word.Document doc)
      {
        // do the actual printing:
        doc.Activate();
        Thread.Sleep(TimeSpan.FromSeconds(1)); // emperical testing found this to be sufficient for our system
        // (a delay may not be required for you if you are printing only one document at a time)
        doc.PrintOut(/* ref objects */);
      }
    
      private bool SetActivePrinter(string printer)
      {
        string oldPrinter = GetActivePrinter(doc); // save this if you want to preserve the existing "default"
    
        if (printer == null)
          return false;
    
        if (oldPrinter != printer)
        {
          // conditionally change the default printer ...
          // we found it inefficient to change the default printer if we don't have to. YMMV.
          doc.Application.ActivePrinter = printer;
          Thread.Sleep(TimeSpan.FromSeconds(5)); // emperical testing found this to be sufficient for our system
          if (GetActivePrinter(doc) != printer)
          {
            // don't quit-and-restart Word, this one actually isn't Word's fault -- just try again
            return false;
          }
    
          // successful printer switch! (as near as anyone can tell)
        }
    
        return true;
      }
    
      private Microsoft.Office.Interop.Word.Document OpenDocument(string fileName)
      {
        return _app.Documents.Open(ref fileName, /* other refs */);
      }
    
      private string GetActivePrinter(Microsoft.Office.Interop.Word._Document doc)
      {
        string activePrinter = doc.Application.ActivePrinter;
        int onIndex = activePrinter.LastIndexOf(" on ");
        if (onIndex >= 0)
        {
          activePrinter = activePrinter.Substring(0, onIndex);
        }
        return activePrinter;
      }
    }
