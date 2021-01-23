    private class NetDocument {
           public string DocumentName {get;set;} //DEFINE DOCUMENT IT RELATED TO !
           ...
           private Logger LogFile { get { return Logger.GetMethodLogger(2); } }   
           private Dictionary<string, NetObject> netObjectHashTable;
           ....
           
      }
