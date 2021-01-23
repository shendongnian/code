    public class LogEntry {
       public string Description { get; set; }
       public DateTime LogDate { get; set; }
       // other properties you want to extract
    }
    public class LogReader {
       public List<LogEntry> ReadLog(string fileName){
           var parsedLog = new List<LogEntry>();
           using(var file = File.Open(filename, ....)){
               while(var line = file.ReadLine()){
                   var logEntry = ParseLine(line);
                   parsedLog.Add(logEntry);
               }
           }
           return parsedLog;
       }
       
       private LogEntry ParseLine(string line){
           var logEntry = new LogEntry();
           // go through the line and parse it with string functions and populate values
       } 
    }
      
