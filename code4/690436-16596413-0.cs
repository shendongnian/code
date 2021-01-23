    public class Url
    {
        private static QueryStringParser _qsp = null;
        public static QueryStringParser QueryStringParser 
        { 
           get
           {
              if(_qsp == null) _qsp = new QueryStringParser();
              return _qsp;
           }
           private set
           { 
               _qsp = value;
           }
        }
    }
