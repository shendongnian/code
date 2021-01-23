    public class FileManager : IDisposable
    {
        private string path;
        private FileStream fileStream;
        public FileManager(string path) 
        {
           this.path = path;
        }
        public void OpenFile()
        {
           this.fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
        }
        public void CloseFile()
        {
          if ( this.fileStream != null && this.fileStream.CanRead)
          {
            this.fileStream.Close();
            this.fileStream.Dispose();
          }
        }
        public void Dispose(){
            this.CloseFile();
        }
    }
    // client
    var manager = new FileManager("path")){
    manager.OpenFile();
    //Do other stuff
    manager.CloseFile()
