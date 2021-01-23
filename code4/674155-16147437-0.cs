    // Create a factory to hold your printer configuration
    // So that it can be retrieved on demand
    // You might need to move the findPrinter() logic
    public class PrintQueueFactory
    {
        private static PrintQueue _instance = new PrinterQueue(/* Details */);
        
        public static PrintQueue PrintQueue { get { return _instance; } }
    }
    
    private int print(StringWriter transformedXML)
    {
        //assume OK
        int rc = 1;
        try
        {
            var printer = PrintQueueFactory.PrintQueue;
            var staThread = new Thread(() => Print(printer, transformedXML.ToString()));
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }
        catch (Exception e)
        {
            //return fail
            rc = -1;
            eventLog.WriteEntry("Error printing: " + e.Message, EventLogEntryType.Error);
        }
        return rc;
    }
    
    private static void Print(PrintQueue printer, string lines)
    {
        using(var printNetterJob = printer.AddJob("PrintNetterPrint"))
        using(var printNetterStreamReader = new StringReader(lines))
        using(var printNetterStream = printNetterJob.JobStream)
        {
            Byte[] printNetterByteBuffer = UnicodeEncoding.Unicode.GetBytes(printNetterStreamReader.ReadToEnd());
            printNetterStream.Write(printNetterByteBuffer, 0, printNetterByteBuffer.Length);
        }
    }
