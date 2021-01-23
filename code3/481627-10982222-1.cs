        public static void listener_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine
                    (
                        "File Created:\n"
                       + "ChangeType: " + e.ChangeType
                       + "\nName: " + e.Name
                       + "\nFullPath: " + e.FullPath
                    );
            try {
                File.Copy(e.FullPath, @"D:\levani\FolderListenerTest\CopiedFilesFolder\" + e.Name);
            }
            catch {
                _waitingForClose.Add(e.FullPath);
            }
            Console.Read();
        }
        public static void listener_Changed(object sender, FileSystemEventArgs e)
        {
             if (_waitingForClose.Contains(e.FullPath))
             {
                  try {
                      File.Copy(...);
                      _waitingForClose.Remove(e.FullPath);
                  }
                  catch {}
             }
       }
