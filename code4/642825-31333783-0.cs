                StringCollection files = Clipboard.GetFileDropList();
                foreach (string file in files)
                {
                    if (System.IO.Directory.Exists(file))
                    {
                      string destPath = info.FullName;
                      FileSystem.CopyDirectory(file, destPath, UIOption.AllDialogs, UICancelOption.DoNothing);
                    
                    }
                 }
