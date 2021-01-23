    public interface IReadableFile
    {
        void ReadFile();
    }
---
    public class MSOfficeWordFile : IReadableFile
    {
        public void ReadFile()
        {
            ReadMSOfficeWordFile(file);
        }
    } 
