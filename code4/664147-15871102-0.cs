    public class FileInfo
    {
         //...
    }
    
    public class FileInfoWithCollection : FileInfo {
         [DisplayName("Messages")]
         public Collection<MessageInfo> MessageInfos { 
              get; 
              set;
         }    
    }
