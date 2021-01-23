    interface ITextParser {
        string Parse(string text);
    }
    public class TableTextParser : ITextParser {
        public string Parse(string text) {
            // specific table parsing stuff here
        }
    }
    
    public class PlainTextParser : ITextParser {
        public string Parse(string text) {
            // specific plain text parsing stuff here
        }
    }
