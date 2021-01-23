    // Partial class declaration
    class FTPManager : IDisposable
    {
    	void Dispose();
    	FTPManager(string host, string username, string password)
    	void UploadFile(string remoteDir, string localfile);
    	void CreateDirectory(string remotePath);
    	void DeleteFile(string remotePath);
    }
    
    // and here I use it:
    void Main()
    {
    	using (var manager = new FTPManager("ftp.somehosting.org","login","password")) {
    		manager.CreateDirectory("/newfolder/");
    		manager.UploadFile("/newfolder/","C:\\Somefile.txt");
    		manager.DeleteFile("/newfolder/anotherfile.txt");
    	}
    }
