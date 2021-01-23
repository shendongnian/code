Queue files = new Queue();
static void Main(string[] args)
       {
    string path = @"";
  FileSystemWatcher listener = new FileSystemWatcher(path);
            Thread t = new Thread(new ThreadStart(ProcessFiles));
            t.Start();
     listener.Created += new FileSystemEventHandler(listener_Created);
       listener.EnableRaisingEvents = true;
          while (Console.ReadLine() != "exit") ;
      }
     public static void listener_Created(object sender, FileSystemEventArgs e)
      {
files.Enqueue(e.FullPath);
        }
void ProcessFiles()
{
    while(true)
    {
        String file = files.Dequeue();`
        while (!IsFileReady(file)) ;`
           File.Copy(e.FullPath, @"D:\levani\FolderListenerTest\CopiedFilesFolder\" + e.Name);
    }
