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
            if(files.Count > 0)
            {
                  String file = files.Dequeue();
                  while (!IsFileReady(file)) ;
                  File.Copy(file, @"D:\levani\FolderListenerTest\CopiedFilesFolder\" +           file);
            }
        }
    }
