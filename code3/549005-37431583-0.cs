    public enum IFIleValue
    {
        F_OK = 0,
        F_WRONG_NAME = -1,
        F_ERROR_OBJECT_DATA = -2,
    };
    
    public interface IFile
    {
         IFIleValue New(String Name=null);
         IFIleValue Open(String Path);
         IFIleValue Save();
         IFIleValue SaveAs(String Path);
         IFIleValue Close();
    }
