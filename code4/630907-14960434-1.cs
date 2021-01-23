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
           // go through the line and parse it with string functions and populate values.
           // I use a helper class, a shortened version is below - note, you might need to
          //adjust to compile
           var parser = new StringParser(line);
           //now just use GetBetween to find the values you need. just pick your delimiters
           // carefully as the parser will move beyond the end string.  But it will go
           // sequentially so just experiment
          logEntry.Description = parser.GetBetween("LOG[", "]LOG");
          // go through in order
       } 
    }
    
    public class StringParser {
        private string text;
        private int position;
        public StringParser(string text)
        {
            this.Text = text;
        }  
        public string Text
        {
            get { return this.text; }
            private set
            {
                this.text = value;
                Position = 0;
            }
        }
        public int Position
        {
            get { return this.position; }
            private set
            {
                if (value < 0)
                {
                    this.position = 0;
                }
                else
                {
                    this.position = value > this.Text.Length ? this.Text.Length : value;
                }
            }
        }
        public bool AtEnd
        {
            get { return this.Position >= this.Text.Length; }
        }
        public string GetBetween(string beforeText, string afterText)
        {
            var startPos = MoveAfter(beforeText);
            if (startPos == -1)
            {
                return "";
            }
            var endPos = FindNext(afterText);
            return GetBetween(startPos, endPos);
        }
        public string GetBetween(int startPos, int endPos)
        {
            if (endPos < 0 || endPos > this.text.Length)
            {
                endPos = this.text.Length;
            } 
            var result = PeekBetween(startPos, endPos);
            if (!string.IsNullOrEmpty(result))
            {
                this.Position = endPos;
            }
            return result;
        }
 
        public int FindNext(string searchText)
        {
            if (string.IsNullOrEmpty(searchText) || this.AtEnd)
            {
                return -1;
            } 
            return this.text.IndexOf(searchText, this.Position, StringComparison.Ordinal);
        }   
        public int MoveAfter(string searchText)
        {
            var found = FindNext(searchText);
            if (found > -1)
            {
                found += searchText.Length;
                this.Position = found;
            }
            return found;
        } 
    }
      
