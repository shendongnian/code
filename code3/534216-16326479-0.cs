    using System;
    using MSUtil;
    
    namespace LogParserTest
    {
     using LogQuery = LogQueryClassClass;
     using EventLogInput = COMEventLogInputContextClassClass;
     using CSVOutput = COMCSVOutputContextClassClass;
     using XMLOutput = COMXMLOutputContextClassClass;
    
     class Program
     {
      static void Main(string[] args)
      {
       try
       {
        // Instantiate the LogQuery object
        LogQuery oLogQuery = new LogQuery();
    
        // Instantiate the Event Log Input Format object
        EventLogInput eventInputFormat = new EventLogInput();
    
        // When set to "FW", events are retrieved from the oldest to the 
        // newest. When set to "BW", events are retrieved from the newest 
        // to the oldest.
        eventInputFormat.direction = "FW"; 
    
        // Event text messages often span multiple lines. When this parameter
        // is set to "ON", the EVT input format preserves readability of the 
        // messages by removing carriage-return, line-feed, and multiple space
        // characters from the message text.
        // When this parameter is set to "OFF", the EVT input format returns
        // the original message text with no intervening post-processing. 
        eventInputFormat.formatMessage = true;
    
        eventInputFormat.binaryFormat = "ASC";
        eventInputFormat.stringsSep = ",";
    
        CSVOutput csvOutputFormat = new CSVOutput();
    
        // ON: always write the header; 
        // OFF: never write the header; 
        // AUTO: write the header only when not appending to an existing file. 
        csvOutputFormat.headers = "ON"; 
        
        // Setting this parameter to "ON" causes the CSV output format to write
        // a tab character after each comma field separator, in order to 
        // improve readability of the CSV output. Note that using tabs between
        // field values might generate output that is not compatible with 
        // certain spreadsheet applications. 
        csvOutputFormat.tabs = false;
        
        // ON: always enclose field values within double-quote characters; 
        // OFF: never enclose field values within double-quote characters; 
        // AUTO: enclose within double-quote characters only those field 
        //    values that contain comma (,) characters. 
        csvOutputFormat.oDQuotes = "AUTO";
    
        // This parameter specifies the date and/or time format to use when
        // formatting values of the TIMESTAMP data type.
        csvOutputFormat.oTsFormat = "yyyy-MM-dd";
        
        // 0 is the system codepage, -1 is UNICODE. 
        csvOutputFormat.oCodepage = -1;
    
        // 0: existing files are appended with the output; 
        // 1: existing files are overwritten with the output; 
        // 2: existing files are left intact, discarding the output. 
        csvOutputFormat.fileMode = 1;
    
        /*
        EventLog     STRING  Name of the Event Log or Event Log backup file 
        RecordNumber   INTEGER  Index of this event
        TimeGenerated   TIMESTAMP Event generated date/time (local time) 
        TimeWritten    TIMESTAMP Event logged date/time (local time) 
        EventID      INTEGER  The ID of the event 
        EventType     INTEGER  The numeric type of the event 
        EventTypeName   STRING  The descriptive type of the event 
        EventCategory   INTEGER  The numeric category of the event 
        EventCategoryName STRING  The descriptive category of the event 
        SourceName    STRING  The source that generated the event 
        Strings      STRING  The textual data
        ComputerName   STRING  The name of the computer  
        SID        STRING  The Security Identifier associated with the event 
        Message      STRING  The full event message 
        Data       STRING  The binary data associated with the event 
        */
    
        string query = @"SELECT TOP 10 EventLog, RecordNumber, Message INTO "
        // Enclose path in single ticks to handle spaces.
        query += "'" + FullPathToCsv + "' FROM "; 
        // Name of application Log, System, Security, Application, CustomLogName
        query += "System";     
        oLogQuery.ExecuteBatch(query, eventInputFormat, csvOutputFormat);
       }
       catch (System.Runtime.InteropServices.COMException ex)
       {
        Console.WriteLine("Unexpected error: " + ex.Message);
       }
      }
     }
    }
