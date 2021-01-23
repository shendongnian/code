    public class Watcher
        {
            public readonly TimeSpan Timeout = TimeSpan.FromMinutes(10);
    
            private readonly FileSystemWatcher m_SystemWatcher;
            private readonly Queue<FileItem> m_Files;
            private readonly Thread m_Thread;
            private readonly object m_SyncObject = new object();
            public Watcher()
            {
                m_Files = new Queue<FileItem>();
                m_SystemWatcher = new FileSystemWatcher();
                m_SystemWatcher.Created += (sender, e) => WatcherHandler(e.FullPath);
                m_Thread = new Thread(ThreadProc)
                    {
                        IsBackground = true
                    };
                m_Thread.Start();
            }
    
            private void WatcherHandler(string fullPath)
            {
                lock (m_SyncObject)
                {
                    m_Files.Enqueue(new FileItem(fullPath));
                }
            }
    
            private void ThreadProc()
            {
             while(true)//cancellation logic needed
             {
                FileItem item = null;
                lock (m_SyncObject)
                {
                    if (m_Files.Count > 0)
                    {
                        item = m_Files.Dequeue();
                    }
                }
    
                if (item != null)
                {
                    CheckAccessAndProcess(item);
                }
                else
                {
                    SpinWait.SpinUntil(() => m_Files.Count > 0, 200);
                }
             }
            }
    
            private void CheckAccessAndProcess(FileItem item)
            {
                if (CheckAccess(item))
                {
                    Process(item);
                }
                else
                {
                    if (DateTime.Now - item.FirstCheck < Timeout)
                    {
                        lock (m_SyncObject)
                        {
                            m_Files.Enqueue(item);
                        }
                    }
                }
            }
    
            private bool CheckAccess(FileItem item)
            {
                if (IsFileLocked(item.Path))
                {
                    if (item.FirstCheck == DateTime.MinValue)
                    {
                        item.SetFirstCheckDateTime(DateTime.Now);
                    }
                    return false;
                }
                
                return true;
            }
    
            private void Process(FileItem item)
            {
                //Do process stuff
            }
            
            private bool IsFileLocked(string file)
            {
                FileStream stream = null;
                var fileInfo = new FileInfo(file);
    
                try
                {
                    stream = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException)
                {
                    return true;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
        }
    
        public class FileItem
        {
            public FileItem(string path)
            {
                Path = path;
                FirstCheck = DateTime.MinValue;
            }
    
            public string Path { get; private set; }
            public DateTime FirstCheck { get; private set; }
    
            public void SetFirstCheckDateTime(DateTime now)
            {
                FirstCheck = now;
            }
        }
