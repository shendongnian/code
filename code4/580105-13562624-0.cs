    [Persistable]
    public sealed class FileMoveTask : TaskBase
    {
         [PersistMember]
         public string SourceFilePath { get; private set;}
    
         [PersistMember]
         public string DestFilePath { get; private set;}
    
         public FileMoveTask(string sourceFilePath, string destFilePath)
         {
             this.SourceFilePath = srcpath;
             this.DestFilePath = dstpath;
    
             //possibly other IMPORTANT initializations
         }
    
         //code
    }
