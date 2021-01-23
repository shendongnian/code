    public abstract class FileTypeMaster
    {
        public abstract CompileThis();
    
        public static FileTypeMaster Create( FileType type )
        {
             switch( type )
             {
                 case FileType.Word : return new WordType();
    
                 case FileType.Pdf : return new PdfType();
       
                 default:
                     throw new NotImplementedException();
             }
        }
    }
