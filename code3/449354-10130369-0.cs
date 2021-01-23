        ....
        EventLog myNewLog = new EventLog();
        myNewLog.Log = "MyCustomLog";                      
        
        myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
        myNewLog.EnableRaisingEvents = true;                 
    }       
    public static void MyOnEntryWritten(object source, EntryWrittenEventArgs e){
    }
