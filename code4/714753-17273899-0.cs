            static void Main(String[] args)
            {
                // Using breath-first search (BFS)
                Queue<DirectoryInfo> myQueue = new Queue<DirectoryInfo>();
    
                // Your storage path here
                myQueue.Enqueue(new DirectoryInfo("C:\\"));
    
                while(myQueue.Count > 0)
                {
                    // Look at the current directory
                    DirectoryInfo crtDI = myQueue.Dequeue();
    
                    // Put the directories from the crt dir in a queue
                    foreach (DirectoryInfo otherDir in GetCrtDirectories(crtDI))
                        myQueue.Enqueue(otherDir);
                    // Do what you want with the directory here 
    		        FixAccess(crtDI);
                }
            }
    
            private static IEnumerable<DirectoryInfo> GetCrtDirectories(DirectoryInfo crtDI)
            {
                foreach(string dirStr in Directory.GetDirectories(crtDI.FullName))
                {
                    DirectoryInfo newDir = new DirectoryInfo(dirStr);
                    yield return newDir;
                }
            }
            private static void FixAccess ( DirectoryInfo DI )
            {
                    foreach (string fileName in System.IO.Directory.GetFiles(DI.FullName))
                    {
                          FileInfo fileInfo = new FileInfo(fileName);
                          FileAttributes attributes = fileInfo.Attributes;
                          if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                          {
                                 // set the attributes to nonreadonly
                                 fileInfo.Attributes &= ~FileAttributes.ReadOnly;
                          }
                    }
            }
